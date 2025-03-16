using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Services.Queries
{
    public interface IBaseQueryService<TEntity, TResultDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TKey : notnull
    {
        Task<IEnumerable<TResultDto>> GetAllAsync(IResolverContext context);
        Task<IEnumerable<TResultDto>> GetByIdsAsync(List<TKey> keys, IResolverContext context);
        Task<TResultDto> GetByIdAsync(TKey key, IResolverContext context);

        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetAll(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryBeforeExecutionForGetById(IQueryable<TEntity> query);

        List<TEntity> TransformEntitiesBeforeMappingForGetAll(List<TEntity> entities);
        List<TEntity> TransformEntitiesBeforeMappingForGetByIds(List<TEntity> entities);
        TEntity TransformEntityBeforeMappingForGetById(TEntity entity);

        List<TResultDto> ModifyDtosAfterMappingForGetAll(List<TResultDto> dtos);
        List<TResultDto> ModifyDtosAfterMappingForGetByIds(List<TResultDto> dtos);
        TResultDto ModifyDtoAfterMappingForGetById(TResultDto dto);
    }
}
