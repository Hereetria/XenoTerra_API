using AutoMapper;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers
{
    public class QueryResolverHelper<TEntity, TKey> : IQueryResolverHelper<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        public async Task<List<TEntity>> ResolveListAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            var connection = await query.ApplyCursorPaginationAsync(context);
            var entities = connection.Edges.Select(e => e.Node).ToList();

            if (entities.Count == 0)
                return [];

            await resolver.PopulateRelatedFieldsAsync(entities, context);
            return entities;
        }

        public async Task<TEntity> ResolveSingleAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            var connection = await query.ApplyCursorPaginationAsync(context);
            var entity = connection.Edges.Select(e => e.Node).FirstOrDefault()
                ?? throw new InvalidOperationException($"{typeof(TEntity).Name} not found");

            await resolver.PopulateRelatedFieldAsync(entity, context);
            return entity;
        }
    }
}
