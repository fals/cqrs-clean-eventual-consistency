using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregate
    {
        Task<TEntity> FindAsync(Guid id); // only allowed find the entity for update or delete
        IQueryable<TEntity> FindAll();
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
