using XenoTerra.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Factories.Abstract
{
    public interface IGenericRepositoryDALFactory
    {
        IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey> CreateRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>()
            where TEntity : class
            where TResultDto : class
            where TResultWithRelationsDto : class
            where TCreateDto : class
            where TUpdateDto : class;
    }
}
