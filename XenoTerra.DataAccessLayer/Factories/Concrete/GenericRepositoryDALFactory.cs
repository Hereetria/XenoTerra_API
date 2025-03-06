using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Factories.Concrete
{
    public class GenericRepositoryDALFactory : IGenericRepositoryDALFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GenericRepositoryDALFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey> CreateRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>()
            where TEntity : class
            where TResultDto : class
            where TResultWithRelationsDto : class
            where TCreateDto : class
            where TUpdateDto : class
        {
            return _serviceProvider.GetRequiredService<IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>>();
        }
    }
}
