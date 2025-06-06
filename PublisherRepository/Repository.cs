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
        public async Task AddAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey().Properties.First();
            var keyName = primaryKey.Name;

            return await _context.Set<T>()
        .FirstOrDefaultAsync(e => EF.Property<int>(e, keyName) == id);
        }
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
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

        public async Task<User?> GetUserByName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == name);
            return user;
        }
    }
}
