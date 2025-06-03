using AutoMapper;
using Core;
using Core.UseCases;
using Microsoft.EntityFrameworkCore;
using PublisherRepository;
using PublisherRepository.Data;
using REST_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext configuration
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
// Or whatever database provider you're using
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<CreateUseCases>();
builder.Services.AddScoped<ArtistUseCase>();
builder.Services.AddScoped<AuthorUseCase>();
builder.Services.AddScoped<BookUseCase>();
builder.Services.AddScoped<CoverUseCase>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//var mapper = app.Services.GetRequiredService<IMapper>();
//mapper.ConfigurationProvider.AssertConfigurationIsValid();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();