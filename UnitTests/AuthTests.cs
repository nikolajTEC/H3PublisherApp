using REST_API.Controllers;
using Core.Services;
using Core.DTO;
using REST_API.Requests;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Castle.Core.Configuration;
using Core;

public class AuthTests
{
    private readonly AuthController _controller;
    private readonly IAuthService _authService;

    public AuthTests()
    {
        var config = Substitute.For<IConfiguration>();
        var repo = Substitute.For<IRepository>();
        _authService = Substitute.For<IAuthService>();

        _controller = new AuthController(_authService);
    }

    [Fact]
    public async Task Register_ShouldReturnOk()
    {
        // Arrange
        var userDTO = new UserDTO { Username = "test", Password = "pass", Role = "User" };

        // Act
        var result = await _controller.Register(userDTO);

        // Assert
        Assert.IsType<OkResult>(result);
        await _authService.Received(1).Register(userDTO);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsToken()
    {
        // Arrange
        var request = new LoginRequest { Name = "test", Password = "pass" };
        _authService.Login(request.Name, request.Password).Returns("fake-jwt-token");

        // Act
        var result = await _controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("fake-jwt-token", okResult.Value);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var request = new LoginRequest { Name = "test", Password = "wrong" };
        _authService.Login(request.Name, request.Password).Returns((string?)null);

        // Act
        var result = await _controller.Login(request);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}
