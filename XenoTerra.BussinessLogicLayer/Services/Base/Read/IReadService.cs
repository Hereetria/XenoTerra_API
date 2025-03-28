using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Read
{
    public interface IReadService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        IQueryable<TEntity> FetchAllQueryable(IEnumerable<string> selectedProperties);
        IQueryable<TEntity> FetchByIdQueryable(TKey key, IEnumerable<string> selectedProperties);
        IQueryable<TEntity> FetchByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties);
    }
}
