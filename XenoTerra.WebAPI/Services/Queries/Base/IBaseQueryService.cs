using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public interface IBaseQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task<IEnumerable<TEntity>> GetAllAsync(IResolverContext context);
        Task<IEnumerable<TEntity>> GetByIdsAsync(List<TKey> keys, IResolverContext context);
        Task<TEntity> GetByIdAsync(TKey key, IResolverContext context);

        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetAll(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetById(IQueryable<TEntity> query);

        List<TEntity> TransformEntitiesBeforeMappingForGetAll(List<TEntity> entities);
        List<TEntity> TransformEntitiesBeforeMappingForGetByIds(List<TEntity> entities);
        TEntity TransformEntityBeforeMappingForGetById(TEntity entity);

        List<TEntity> ModifyDtosAfterMappingForGetAll(List<TEntity> dtos);
        List<TEntity> ModifyDtosAfterMappingForGetByIds(List<TEntity> dtos);
        TEntity ModifyDtoAfterMappingForGetById(TEntity dto);
    }
}
