using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Repositories.Generic.Read
{
    public interface IReadRepository<TEntity, TDtoResult, TKey>
        where TDtoResult : class
        where TEntity : class
        where TKey : notnull
    {
        AppDbContext GetDbContext();
        IQueryable<TDtoResult> GetAllQueryable(IEnumerable<string> selectedFields);
        IQueryable<TDtoResult> GetByIdQueryable(TKey key, IEnumerable<string> selectedFields);
        IQueryable<TDtoResult> GetByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedFields);
    }
}
