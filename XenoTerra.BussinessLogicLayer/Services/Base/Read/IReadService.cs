using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Read
{
    public interface IReadService<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        IQueryable<TDtoResult> FetchAllQueryable(IEnumerable<string> selectedProperties);
        IQueryable<TDtoResult> FetchByIdQueryable(TKey key, IEnumerable<string> selectedProperties);
        IQueryable<TDtoResult> FetchByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties);
    }
}
