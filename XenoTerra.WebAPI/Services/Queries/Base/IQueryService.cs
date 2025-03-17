using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public interface IQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task<IEnumerable<TEntity>> GetAllAsync(IResolverContext context);
        Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> keys, IResolverContext context);
        Task<TEntity> GetByIdAsync(TKey key, IResolverContext context);

        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetAll(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetById(IQueryable<TEntity> query);

        IEnumerable<TEntity> TransformEntitiesAfterExecutionForGetAll(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> TransformEntitiesAfterExecutionForGetByIds(IEnumerable<TEntity> entities);
        TEntity TransformEntityAfterExecutionForGetById(TEntity entity);
    }
}
