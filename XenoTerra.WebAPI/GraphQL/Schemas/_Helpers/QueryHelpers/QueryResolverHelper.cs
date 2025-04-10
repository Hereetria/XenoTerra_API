﻿using AutoMapper;
using GreenDonut.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers
{
    public class QueryResolverHelper<TEntity, TKey> : IQueryResolverHelper<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        public async Task<Connection<TEntity>> ResolveEntityConnectionAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            var connection = ConnectionBuilder.BuildConnection(query, context);

            var entities = connection.Edges.Select(e => e.Node).Where(e => e is not null).ToList();

            if (entities.Count > 0)
                await resolver.PopulateRelatedFieldsAsync(entities, context);

            return new Connection<TEntity>(
                connection.Edges,
                connection.Info,
                connection.TotalCount
            );
        }

        public async Task<List<TEntity>> ResolveEntitiesAsync(
            IQueryable<TEntity> query,
            IEntityResolver<TEntity, TKey> resolver,
            IResolverContext context)
        {
            List<TEntity> entities;

            if (GraphQLFieldProvider.IsPaginatedMethod(context))
            {
                var connection = ConnectionBuilder.BuildConnection(query, context);

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
                return [];
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
