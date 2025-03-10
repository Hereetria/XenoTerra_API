using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Read
{
    public interface IReadService<TEntity, TResultWithRelationsDto, TKey>
        where TEntity : class
        where TResultWithRelationsDto : class
    {
        IQueryable<TResultWithRelationsDto> GetAll(IEnumerable<string> selectedProperties);
        IQueryable<TResultWithRelationsDto> GetById(TKey key, IEnumerable<string> selectedProperties);
        IQueryable<TResultWithRelationsDto> GetByIds(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties);
    }
}
