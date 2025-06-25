using Core;
using Core.UseCases;
using Microsoft.EntityFrameworkCore;
using PublisherRepository;
using PublisherRepository.Data;
using REST_API.Objects;
using REST_API.Requests;

namespace UnitTests
{
    public class BookTests
    {
        private readonly DataContext _context;
        private readonly BookUseCase _useCase;
        private readonly IRepository _repo;
        private readonly IGenericRepo _genericRepo; 
        public BookTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new DataContext(options);
            _repo = new Repository(_context);
            _genericRepo = new GenericRepo(_context);
            _useCase = new BookUseCase(_genericRepo, _repo);

            SeedTestData();
        }

        private SearchBooksRequest GetSearchBookRequest(string? name = null, DateTime? startDate = null, DateTime? endDate = null, double? price = null, bool under = false)
        {
            return new SearchBooksRequest()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                Under = under
            };
        }

        private void SeedTestData()
        {
            // Create Artists
            var artists = new List<Artists>
        {
            new Artists { Id = 1, FirstName = "John", LastName = "Doe" },
            new Artists { Id = 2, FirstName = "Jane", LastName = "Test"}
        };

            // Create Covers
            var covers = new List<Covers>
        {
            new Covers { Id = 1, Title = "Fantasy Cover" },
            new Covers { Id = 2, Title = "Sci-Fi Cover" },
            new Covers { Id = 3, Title = "Romance Cover" }
        };

            // Create Books with various scenarios
            var books = new List<Books>
        {
            new Books
            {
                Id = 1,
                Title = "The Great Adventure",
                PublishDate = new DateOnly(2020, 1, 15),
                BasePrice = 19.99,
                CoverId = 1
            },
            new Books
            {
                Id = 2,
                Title = "Space Odyssey",
                PublishDate = new DateOnly(2021, 6, 20),
                BasePrice = 24.99,
                CoverId = 2
            },
            new Books
            {
                Id = 3,
                Title = "Love Story",
                PublishDate = new DateOnly(2022, 12, 10),
                BasePrice = 15.50,
                CoverId = 3
            },
            new Books
            {
                Id = 4,
                Title = "Adventure Continues",
                PublishDate = new DateOnly(2023, 3, 5),
                BasePrice = 29.99,
                CoverId = 1
            },
            new Books
            {
                Id = 5,
                Title = "Mystery Novel",
                PublishDate = new DateOnly(2019, 8, 12),
                BasePrice = 22.00,
                CoverId = null
            }
        };

            // Create ArtistCovers
            var artistCovers = new List<ArtistCover>
        {
            new ArtistCover { ArtistsId = 1, CoversId = 1},
            new ArtistCover { ArtistsId = 2, CoversId = 2},
            new ArtistCover { ArtistsId = 3, CoversId = 3}
        };

            _context.Artists.AddRange(artists);
            _context.Covers.AddRange(covers);
            _context.Books.AddRange(books);
            _context.ArtistCovers.AddRange(artistCovers);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetBooksBySearchCriteriaAsync_NoFilters_ReturnsAllBooks()
        {
            // Act
            var result = await _useCase.GetBooksBySearchCriteriaAsync(null, null, null, null, false);

            // Assert
            Assert.Equal(5, result.Count);
            Assert.Contains(result, b => b.Title == "The Great Adventure");
            Assert.Contains(result, b => b.Title == "Space Odyssey");
            Assert.Contains(result, b => b.Title == "Love Story");
            Assert.Contains(result, b => b.Title == "Adventure Continues");
            Assert.Contains(result, b => b.Title == "Mystery Novel");
        }

        [Fact]
        public async Task SearchBooks_WithPriceFilterUnder_ReturnsCorrectBooks()
        {
            // Act
            var result = await _useCase.GetBooksBySearchCriteriaAsync(null, null, null, 20.0, true);

            // Assert

            Assert.Equal(2, result.Count);
            Assert.All(result, book => Assert.True(book.BasePrice <= 20.0));
        }
        [Fact]

        public async Task SearchBooks_WithAllFilters_ReturnsCorrectBooks()
        {

            // Act
            var result = await _useCase.GetBooksBySearchCriteriaAsync("Adventure", new DateTime(2020, 1, 1), new DateTime(2023, 12, 31), 25.0, false);

            // Assert

            Assert.Single(result);
            Assert.Equal("Adventure Continues", result[0].Title);
            Assert.True(result[0].BasePrice >= 25.0);
        }
    }
}
