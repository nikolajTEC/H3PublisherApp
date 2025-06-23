using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public abstract class CrudUseCase<T> where T : class
    {
        private readonly IGenericRepo _genericRepo;

        public CrudUseCase(IGenericRepo genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public Task AddAsync(T entity) => _genericRepo.AddAsync(entity);
        public Task<T> GetByIdAsync(int id) => _genericRepo.GetByIdAsync<T>(id);
        public Task UpdateAsync(T entity) => _genericRepo.UpdateAsync(entity);
        public Task DeleteAsync(T entity) => _genericRepo.DeleteAsync(entity);
    }
}
