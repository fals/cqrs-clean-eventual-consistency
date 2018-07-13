using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Interfaces
{
    public interface IMaterialize<TEntity, TQModel> where TEntity: IEntity where TQModel : IQueryModel
    {
        TQModel Materialize(TEntity entity);
    }
}
