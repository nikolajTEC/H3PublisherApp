using Azure.Core;
using Core;
using Core.Objects;
using Microsoft.EntityFrameworkCore;
using PublisherRepository.Data;
using REST_API.Objects;

namespace PublisherRepository
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Authors>> GetAuthorsAsNoTracking()
        {
            var authors = await _context.Authors
                .Include(a => a.Books)
                    .ThenInclude(b => b.Cover)
                        .ThenInclude(c => c.ArtistCovers)
                            .ThenInclude(ac => ac.Artist)
                            .AsNoTracking()
                .ToListAsync();
            return authors;
        }

        public async Task<List<Books>> GetBooksByAuthorIdAsNoTracking(int authorId)
        {
            var books = await _context.Books
                .Where(x => x.AuthorId == authorId)
                .Include(x => x.Cover)
                .ThenInclude(x => x.ArtistCovers)
                .ThenInclude(x => x.Artist)
                .AsNoTracking()
                .ToListAsync();
            return books;
        }
        public async Task<List<Books>> GetBooksAsNoTracking()
        {
            var books = await _context.Books
                .Include(x => x.Cover)
                .ThenInclude(x => x.ArtistCovers)
                .ThenInclude(x => x.Artist)
                .AsNoTracking()
                .ToListAsync();
            return books;
        }

        public async Task<Books> GetBookAndChildObjectsAsync(int id)
        {
            var books = await _context.Books
                .Include(x => x.Cover)
                .ThenInclude(x => x.ArtistCovers)
                .ThenInclude(x => x.Artist)
                .FirstOrDefaultAsync();
            return books;
        }

        public async Task<User?> GetUserByName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == name);
            return user;
        }

        public async Task<List<Books>> GetBooksBySearchCriteriaAsync(string? name, DateTime? startDate, DateTime? endDate, double? price, bool under)
        {
            var query = _context.Books
                .Include(x => x.Cover)
                .ThenInclude(x => x.ArtistCovers)
                .ThenInclude(x => x.Artist)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(b => b.Title.Contains(name));

            if (startDate.HasValue)
            {
                var start = DateOnly.FromDateTime((DateTime)startDate);
                query = query.Where(b => b.PublishDate >= start);
            }

            if (endDate.HasValue)
            {
                var end = DateOnly.FromDateTime((DateTime)endDate);
                query = query.Where(b => b.PublishDate <= end);
            }

            if (price.HasValue)
            {
                if (!under)
                    query = query.Where(b => b.BasePrice >= price);
                else
                    query = query.Where(b => b.BasePrice <= price);
            }

            var books = await query.ToListAsync();

            return books;

        }
    }
}
