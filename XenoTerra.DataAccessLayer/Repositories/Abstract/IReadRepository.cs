using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Repositories.Abstract
{
    public interface IReadRepository<TEntity, TKey>
        where TEntity : class
    {
        IQueryable<TEntity> GetAllQueryable();
        IQueryable<TEntity> GetByIdQueryable(TKey key);
        IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys);
    }
}
