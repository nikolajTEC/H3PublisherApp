namespace Core
{
    public interface IGenericRepo
    {
        Task AddAsync<T>(T entity) where T : class;

        Task<T> GetByIdAsync<T>(int id) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;

        Task DeleteAsync<T>(T entity) where T : class;
    }
}
