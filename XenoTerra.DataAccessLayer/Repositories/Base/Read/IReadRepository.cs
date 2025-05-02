using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Repositories.Base.Read
{
    public interface IReadRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        IQueryable<TEntity> GetRawQueryable();
        IQueryable<TEntity> GetAllQueryable(IQueryable<TEntity> query, IEnumerable<string> selectedFields);
        IQueryable<TEntity> GetByIdQueryable(IQueryable<TEntity> query, TKey key, IEnumerable<string> selectedFields);
        IQueryable<TEntity> GetByIdsQueryable(IQueryable<TEntity> query, IEnumerable<TKey> keys, IEnumerable<string> selectedFields);
    }
}
