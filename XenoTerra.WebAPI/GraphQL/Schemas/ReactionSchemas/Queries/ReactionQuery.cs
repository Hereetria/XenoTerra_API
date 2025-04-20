using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries
{
    public class ReactionQuery(IMapper mapper, IQueryResolverHelper<Reaction, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Reaction, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionFilterType))]
        [UseSorting(typeof(ReactionSortType))]
        public async Task<ReactionConnection> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionConnection, ResultReactionWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionFilterType))]
        [UseSorting(typeof(ReactionSortType))]
        public async Task<ReactionConnection> GetReactionsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionConnection, ResultReactionWithRelationsDto>(connection);
        }

        public async Task<ResultReactionWithRelationsDto?> GetReactionByIdAsync(
            string? key,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultReactionWithRelationsDto>(entity);
        }
    }
}
