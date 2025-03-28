using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Write
{
    public interface IWriteService<TEntity, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        Task<TEntity> CreateAsync(TCreateDto createDto);
        Task<TEntity> UpdateAsync(TUpdateDto updateDto);
        Task<bool> DeleteAsync(TKey key);
    }
}
