
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Repositories;
using System.Linq.Expressions;

namespace XenoTerra.BussinessLogicLayer.Repositories
{
        public abstract class GenericRepositoryBLL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>
        : IGenericRepositoryBLL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultWithRelationsDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        private readonly IGenericRepositoryDALFactory _repositoryDALFactory;
        protected readonly IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey> _repositoryDAL;

        public GenericRepositoryBLL(IGenericRepositoryDALFactory repositoryDALFactory)
        {
            _repositoryDALFactory = repositoryDALFactory;
            _repositoryDAL = _repositoryDALFactory.CreateRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>();
        }

        public async Task<List<Guid>> GetAllIdsAsync()
        {
            var result = await _repositoryDAL.TGetAllIdsAsync();
            return result;
        }

        public IQueryable<TResultDto> GetByIdsQuerable(IEnumerable<Guid> ids)
        {
            var result = _repositoryDAL.TGetByIdsQuerable(ids);
            return result;
        }

        public Task<IEnumerable<TResultWithRelationsDto>> GetByIdsWithRelationsAsync(IEnumerable<Guid> ids, IEnumerable<string> selectedFields)
        {
            var result = _repositoryDAL.TGetByIdsWithRelationsAsync(ids, selectedFields);
            return result;
        }

        public async Task<TResultDto> CreateAsync(TCreateDto createDto)
        {
            var result = await _repositoryDAL.TCreateAsync(createDto);
            return result;
        }

        public async Task<TResultDto> UpdateAsync(TUpdateDto updateDto)
        {
            var result = await _repositoryDAL.TUpdateAsync(updateDto);
            return result;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var result = await _repositoryDAL.TDeleteAsync(id);
            return result;
        }

        protected async Task<List<TResultQueryDto>> GetEntitiesByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class
        {
            var values = await _repositoryDAL.TGetEntitiesByQueryAsync<TResultQueryDto>(query);
            return values;
        }

        protected async Task<TResultQueryDto?> GetEntityByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class
        {
            var values = await _repositoryDAL.TGetEntityByQueryAsync<TResultQueryDto>(query);
            return values;
        }

        protected async Task<List<TResultQueryDto>> GetSelectedEntitiesByQueryAsync<TResultQueryDto, TResultEntity>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
            Expression<Func<TEntity, TResultEntity>> selectExpression)
            where TResultQueryDto : class
            where TResultEntity : class
        {
            var values = await _repositoryDAL.TGetSelectedEntitiesByQueryAsync<TResultQueryDto, TResultEntity>(query, selectExpression);
            return values;
        }
    }
}