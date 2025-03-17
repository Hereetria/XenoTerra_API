using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Read
{
    public interface IReadRepository<TEntity, TKey>
        where TEntity : class
    {
        AppDbContext GetDbContext();
        IQueryable<TEntity> GetAllQueryable();
        IQueryable<TEntity> GetByIdQueryable(TKey key);
        IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys);
    }
}
