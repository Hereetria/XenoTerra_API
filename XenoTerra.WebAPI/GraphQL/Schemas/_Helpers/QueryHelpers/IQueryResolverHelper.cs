using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers
{
    public interface IQueryResolverHelper<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task<List<TEntity>> ResolveEntitiesAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context);

        Task<TEntity> ResolveEntityAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context);

        Task<Connection<TEntity>> ResolveEntityConnectionAsync(
    IQueryable<TEntity> query,
    IEntityResolver<TEntity, TKey> resolver,
    IResolverContext context);
    }

}
