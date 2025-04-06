using AutoMapper;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers
{
    public class QueryResolverHelper<TEntity, TKey> : IQueryResolverHelper<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        public async Task<List<TEntity>> ResolveEntitiesAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            List<TEntity> entities;

            if (GraphQLFieldProvider.IsPaginatedMethod(context))
            {
                var connection = await query.ApplyCursorPaginationAsync(context);
                entities = [.. connection.Edges
                    .Select(e => e.Node)
                    .Where(e => e is not null)];
            }
            else
            {
                entities = await query.ToListAsync();
            }

            if (entities.Count == 0)
            {
                throw GraphQLExceptionFactory.Create(
                    $"{typeof(TEntity).Name} not found.",
                    [$"No {typeof(TEntity).Name} entities were found for the given IDs."],
                    "ENTITIES_NOT_FOUND"
                );
            }

            await resolver.PopulateRelatedFieldsAsync(entities, context);
            return entities;
        }

        public async Task<TEntity> ResolveEntityAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            TEntity? entity;

            if (GraphQLFieldProvider.IsPaginatedMethod(context))
            {
                var connection = await query.ApplyCursorPaginationAsync(context);
                var firstEdge = connection?.Edges != null && connection.Edges.Count > 0
                ? connection.Edges[0]
                : null;

                entity = firstEdge?.Node;

            }
            else
            {
                entity = await query.FirstOrDefaultAsync();
            }

            if (entity is null)
            {
                throw GraphQLExceptionFactory.Create(
                    $"{typeof(TEntity).Name} not found.",
                    [$"No {typeof(TEntity).Name} entity was found for the given ID."],
                    "ENTITY_NOT_FOUND"
                );
            }


            await resolver.PopulateRelatedFieldAsync(entity, context);
            return entity;
        }
    }
}
