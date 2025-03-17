using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Write
{
    public interface IWriteService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
    {
        Task<TResultDto> CreateAsync(TCreateDto createDto);
        Task<TResultDto> UpdateAsync(TUpdateDto updateDto);
        Task<bool> DeleteAsync(TKey key);
    }
}
