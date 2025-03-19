using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public class QueryService<TEntity, TDtoResult, TKey> : IQueryService<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        protected readonly IReadService<TEntity, TDtoResult, TKey> _readService;
        protected readonly IMapper _mapper;

        public QueryService(IReadService<TEntity, TDtoResult, TKey> readService, IMapper mapper)
        {
            _readService = readService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDtoResult>> GetAllAsync(IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchAllQueryable(selectedFields) ?? Enumerable.Empty<TDtoResult>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetAll(query);

            var entities = await query.ToListAsync();
            var transformedEntities = TransformEntitiesAfterExecutionForGetAll(entities);

            return transformedEntities;
        }

        public async Task<IEnumerable<TDtoResult>> GetByIdsAsync(IEnumerable<TKey> keys, IResolverContext context)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdsQueryable(keys, selectedFields) ?? Enumerable.Empty<TDtoResult>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetByIds(query);

            var entities = await query.ToListAsync();
            var transformedEntities = TransformEntitiesAfterExecutionForGetByIds(entities);

            return transformedEntities;
        }

        public async Task<TDtoResult> GetByIdAsync(TKey key, IResolverContext context)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdQueryable(key, selectedFields) ?? Enumerable.Empty<TDtoResult>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetById(query);

            var entity = await query.FirstOrDefaultAsync()
                ?? throw new System.Collections.Generic.KeyNotFoundException($"{typeof(TEntity).Name} with ID {key} was not found.");

            var transformedEntities = TransformEntityAfterExecutionForGetById(entity);

            return transformedEntities;
        }

        public virtual IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetAll(IQueryable<TDtoResult> query) => query;
        public virtual IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TDtoResult> query) => query;
        public virtual IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetById(IQueryable<TDtoResult> query) => query;

        public virtual IEnumerable<TDtoResult> TransformEntitiesAfterExecutionForGetAll(IEnumerable<TDtoResult> entities) => entities;
        public virtual IEnumerable<TDtoResult> TransformEntitiesAfterExecutionForGetByIds(IEnumerable<TDtoResult> entities) => entities;
        public virtual TDtoResult TransformEntityAfterExecutionForGetById(TDtoResult entity) => entity;
    }
}
