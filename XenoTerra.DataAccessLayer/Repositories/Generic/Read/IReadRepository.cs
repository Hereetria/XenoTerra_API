using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Read
{
    public interface IReadRepository<TEntity, TKey>
        where TEntity : class
    {
        IQueryable<TEntity> QueryAll();
        IQueryable<TEntity> QueryById(TKey key);
        IQueryable<TEntity> QueryByIds(IEnumerable<TKey> keys);
    }
}
