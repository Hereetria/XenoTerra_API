using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own
{
    public interface IStoryOwnWriteService<TEntity, TCreateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TKey : notnull
    {
        Task<TEntity> CreateStoryAsync(TCreateDto createDto);
        Task<TEntity> DeleteStoryAsync(TKey key);
    }

}
