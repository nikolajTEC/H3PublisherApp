using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using REST_API.Objects;
using PublisherRepository;
using PublisherRepository.Data;

public class GenericRepoTests : IDisposable
{
    private readonly DataContext _context;
    private readonly GenericRepo _repository;

    public GenericRepoTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
        _repository = new GenericRepo(_context);
        _context.Database.EnsureCreated();
    }

    [Theory]
    [MemberData(nameof(GetEntityTestData))]
    public async Task AddAsync_ShouldAddEntityToDatabase<T>(T entity, string entityName) where T : class
    {
        // Act
        await _repository.AddAsync(entity);

        var addedEntity = await _repository.GetByIdAsync<T>(1);
        Assert.NotNull(addedEntity);
    }

    [Theory]
    [MemberData(nameof(GetEntityTestData))]
    public async Task GetByIdAsync_WithValidId_ShouldReturnEntity<T>(T entity, string entityName) where T : class
    {
        // Arrange
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        var entityType = _context.Model.FindEntityType(typeof(T));
        var primaryKey = entityType.FindPrimaryKey().Properties.First();
        var keyName = primaryKey.Name;

        // Act
        var result = await _repository.GetByIdAsync<T>(1);

        // Assert
        Assert.NotNull(result);
        var entityId = (int)typeof(T).GetProperty(keyName).GetValue(entity);
        Assert.Equal(1, entityId);
    }

    [Theory]
    [MemberData(nameof(GetEntityTestData))]
    public async Task DeleteAsync_WithValidEntity_ShouldRemoveFromDatabase<T>(T entity, string entityName) where T : class
    {
        // Arrange
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        var entityType = _context.Model.FindEntityType(typeof(T));
        var primaryKey = entityType.FindPrimaryKey().Properties.First();
        var keyName = primaryKey.Name;
        var entityId = (int)typeof(T).GetProperty(keyName).GetValue(entity);

        // Act
        await _repository.DeleteAsync(entity);

        // Assert
        var deletedEntity = await _repository.GetByIdAsync<T>(entityId);
        Assert.Null(deletedEntity);
    }

    public static IEnumerable<object[]> GetEntityTestData()
    {
        yield return new object[] { new Artists("Test", "Artist"), "Artists" };
        yield return new object[] { new Authors("Test", "Author"), "Authors" };
        yield return new object[] { new Books("Test Book", DateOnly.FromDateTime(DateTime.Now), 29.99, 1), "Books" };
        yield return new object[] { new Covers("Test Cover", false, 1), "Covers" };
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}