using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Technical;

namespace XenoTerra.BussinessLogicLayer.Helpers
{
    public static class MappingGuard
    {
        public static TEntity MapOrThrow<TEntity, TDto>(IMapper mapper, TDto dto)
            where TEntity : class
            where TDto : class
        {
            try
            {
                return mapper.Map<TEntity>(dto)
                    ?? throw new MappingFailedException(typeof(TDto).Name, typeof(TEntity).Name);
            }
            catch (Exception ex)
            {
                throw new MappingFailedException(typeof(TDto).Name, typeof(TEntity).Name, ex);
            }
        }
    }
}
