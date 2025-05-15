using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries
{
    public class RecentChatsQuery(IMapper mapper, IQueryResolverHelper<RecentChats, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<RecentChats, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsFilterType))]
        [UseSorting(typeof(RecentChatsSortType))]
        public async Task<RecentChatsConnection> GetAllRecentChatsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsConnection, ResultRecentChatsWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsFilterType))]
        [UseSorting(typeof(RecentChatsSortType))]
        public async Task<RecentChatsConnection> GetRecentChatsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsConnection, ResultRecentChatsWithRelationsDto>(connection);
        }

        public async Task<ResultRecentChatsWithRelationsDto?> GetRecentChatsByIdAsync(
            string? key,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultRecentChatsWithRelationsDto>(entity);
        }
    }
}
