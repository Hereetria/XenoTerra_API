using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public class QueryService<TEntity, TKey> : IQueryService<TEntity, TKey>
       where TEntity : class
       where TKey : notnull
    {
        protected readonly IReadService<TEntity, TKey> _readService;
        protected readonly IMapper _mapper;

        public QueryService(IReadService<TEntity, TKey> readService, IMapper mapper)
        {
            _readService = readService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchAllQueryable(selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetAll(query);

            var entities = await query.ToListAsync();
            var transformedEntities = TransformEntitiesAfterExecutionForGetAll(entities);

            return transformedEntities;
        }

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> keys, IResolverContext context)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdsQueryable(keys, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetByIds(query);

            var entities = await query.ToListAsync();
            var transformedEntities = TransformEntitiesAfterExecutionForGetByIds(entities);

            return transformedEntities;
        }

        public async Task<TEntity> GetByIdAsync(TKey key, IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdQueryable(key, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetById(query);

            var entity = await query.FirstOrDefaultAsync()
                ?? throw new System.Collections.Generic.KeyNotFoundException($"{typeof(TEntity).Name} with ID {key} was not found.");

            var transformedEntities = TransformEntityAfterExecutionForGetById(entity);

            return transformedEntities;
        }

        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetAll(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetById(IQueryable<TEntity> query) => query;

        public virtual IEnumerable<TEntity> TransformEntitiesAfterExecutionForGetAll(IEnumerable<TEntity> entities) => entities;
        public virtual IEnumerable<TEntity> TransformEntitiesAfterExecutionForGetByIds(IEnumerable<TEntity> entities) => entities;
        public virtual TEntity TransformEntityAfterExecutionForGetById(TEntity entity) => entity;
    }
}
