using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries
{
    public class FollowSelfQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(FollowSelfFilterType))]
        [UseSorting(typeof(FollowSelfSortType))]
        public async Task<FollowSelfConnection> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Follow, ResultFollowWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowSelfConnection, ResultFollowWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(FollowSelfFilterType))]
        [UseSorting(typeof(FollowSelfSortType))]
        public async Task<FollowSelfConnection> GetFollowsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Follow, ResultFollowWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowSelfConnection, ResultFollowWithRelationsDto>(connection);
        }

        public async Task<ResultFollowWithRelationsDto?> GetFollowByIdAsync(
            string? key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultFollowWithRelationsDto>(entity);
        }
    }

}
