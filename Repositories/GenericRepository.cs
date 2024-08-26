using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Interfaces;

namespace UnitOfWorkDemo.Services
{
    // Implementation the CRUD operation for the Generic-interface
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContextClass _context;

        public GenericRepository(DbContextClass context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
