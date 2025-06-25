using Core;
using Microsoft.EntityFrameworkCore;
using PublisherRepository.Data;

namespace PublisherRepository
{
    public class GenericRepo : IGenericRepo
    {
        private readonly DataContext _context;

        public GenericRepo(DataContext context)
        {
            _context = context;
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
            _context.ChangeTracker.Clear();
            _context.Set<T>().Update(entity);
            try
            {
            await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
