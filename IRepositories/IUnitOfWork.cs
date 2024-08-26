namespace UnitOfWorkDemo.Interfaces
{
    // Implementing the UnitOfWork for CRUD operations
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Save();
    }
}
