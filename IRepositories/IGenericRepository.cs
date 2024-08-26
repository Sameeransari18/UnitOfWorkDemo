namespace UnitOfWorkDemo.Interfaces
{
    // Created an Generic interface for DbContext Methods
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
