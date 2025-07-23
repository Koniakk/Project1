using Project1.Entity;

namespace Project1.Core.Service
{
    public interface IDataEntityService<T> where T : IdentifiableEntity
    {
        Task<IEnumerable<T>> Get(DbSet<T> dbSet, List<int> ids);
        Task<bool> Set(DbSet<T> dbSet, List<T> entities);
        Task<bool> Delete(DbSet<T> dbSet, List<int> ids);
    }
}

//{
//    internal class IDDataSource
//    {
//    }
//}
