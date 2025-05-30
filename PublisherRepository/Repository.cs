using Core;
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
        public async Task AddAuthor(Authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task AddBook(Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task AddCover(Covers cover)
        {
            _context.Covers.Add(cover);
            await _context.SaveChangesAsync();
        }

        public async Task AddArtist(Artists artists)
        {
            _context.Artists.Add(artists);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Authors>> GetAuthors()
        {
            var authors = await _context.Authors
                .Include(a => a.Books)
                    .ThenInclude(b => b.Cover)
                        .ThenInclude(c => c.ArtistCovers)
                            .ThenInclude(ac => ac.Artist)
                .ToListAsync();
            return authors;
        }
    }
}
