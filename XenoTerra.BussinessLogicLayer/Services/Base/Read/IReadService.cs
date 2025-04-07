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
        IQueryable<TEntity> GetRawQueryable();
        IQueryable<TEntity> FetchAllQueryable(IQueryable<TEntity> query, IEnumerable<string> selectedFields);
        IQueryable<TEntity> FetchByIdQueryable(IQueryable<TEntity> query, TKey key, IEnumerable<string> selectedFields);
        IQueryable<TEntity> FetchByIdsQueryable(IQueryable<TEntity> query, IEnumerable<TKey> keys, IEnumerable<string> selectedFields);
    }
}
