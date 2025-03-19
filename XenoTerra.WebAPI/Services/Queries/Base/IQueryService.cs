using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public interface IQueryService<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        Task<IEnumerable<TDtoResult>> GetAllAsync(IResolverContext context);
        Task<IEnumerable<TDtoResult>> GetByIdsAsync(IEnumerable<TKey> keys, IResolverContext context);
        Task<TDtoResult> GetByIdAsync(TKey key, IResolverContext context);

        IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetAll(IQueryable<TDtoResult> query);
        IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TDtoResult> query);
        IQueryable<TDtoResult> ModifyQueryBeforeExecutionForGetById(IQueryable<TDtoResult> query);

        IEnumerable<TDtoResult> TransformEntitiesAfterExecutionForGetAll(IEnumerable<TDtoResult> entities);
        IEnumerable<TDtoResult> TransformEntitiesAfterExecutionForGetByIds(IEnumerable<TDtoResult> entities);
        TDtoResult TransformEntityAfterExecutionForGetById(TDtoResult entity);
    }
}
