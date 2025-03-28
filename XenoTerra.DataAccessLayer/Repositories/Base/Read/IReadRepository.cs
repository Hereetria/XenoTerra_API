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
        AppDbContext GetDbContext();
        IQueryable<TEntity> GetAllQueryable(IEnumerable<string> selectedFields);
        IQueryable<TEntity> GetByIdQueryable(TKey key, IEnumerable<string> selectedFields);
        IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedFields);
    }
}
