//using System.Linq;
//using System.Threading.Tasks;

//namespace FastUI.Core
//{
//    public interface IDatabase
//    {
//        Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : IEntity;

//        Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : IEntity;

//        Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : IEntity;

//        IQueryable<TEntity> Query<TEntity>() where TEntity : IEntity;
//    }
//}