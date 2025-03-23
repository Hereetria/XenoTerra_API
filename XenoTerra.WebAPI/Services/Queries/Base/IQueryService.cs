using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public interface IQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        IQueryable<TEntity> GetAllQueryable(IResolverContext context);
        IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys, IResolverContext context);
        IQueryable<TEntity> GetByIdQueryable(TKey key, IResolverContext context);

        IQueryable<TEntity> ModifyQueryForGetAll(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryForGetByIds(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryForGetById(IQueryable<TEntity> query);

    }
}
