using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.RecentChatsResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class RecentChatsSelfQuery(IMapper mapper, IQueryResolverHelper<RecentChats, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<RecentChats, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsSelfFilterType))]
        [UseSorting(typeof(RecentChatsSelfSortType))]
        public async Task<RecentChatsSelfConnection> GetAllRecentChatsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateRecentChatsAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsSelfConnection, ResultRecentChatsWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsSelfFilterType))]
        [UseSorting(typeof(RecentChatsSelfSortType))]
        public async Task<RecentChatsSelfConnection> GetRecentChatsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateRecentChatsAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsSelfConnection, ResultRecentChatsWithRelationsDto>(connection);
        }

        public async Task<ResultRecentChatsWithRelationsDto?> GetRecentChatsByIdAsync(
            string? key,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateRecentChatsAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultRecentChatsWithRelationsDto>(entity);
        }

        private static Expression<Func<RecentChats, bool>> CreateRecentChatsAccessFilter(Guid currentUserId)
            => recentChats => recentChats.UserId == currentUserId;
        
    }
}
