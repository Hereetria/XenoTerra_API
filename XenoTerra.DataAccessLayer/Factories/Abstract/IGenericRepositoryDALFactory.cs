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
        IGenericRepositoryDAL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey> CreateRepositoryDAL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey>()
            where TEntity : class
            where TResultDto : class
            where TResultById : class
            where TCreateDto : class
            where TUpdateDto : class;
    }
}
