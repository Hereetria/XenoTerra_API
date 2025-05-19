using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NotificationResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class NotificationSelfQuery(IMapper mapper, IQueryResolverHelper<Notification, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Notification, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationSelfFilterType))]
        [UseSorting(typeof(NotificationSelfSortType))]
        public async Task<NotificationSelfConnection> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateNotificationAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationSelfConnection, ResultNotificationWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationSelfFilterType))]
        [UseSorting(typeof(NotificationSelfSortType))]
        public async Task<NotificationSelfConnection> GetNotificationsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateNotificationAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationSelfConnection, ResultNotificationWithRelationsDto>(connection);
        }

        public async Task<ResultNotificationWithRelationsDto?> GetNotificationByIdAsync(
            string? key,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateNotificationAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNotificationWithRelationsDto>(entity);
        }

        private static Expression<Func<Notification, bool>> CreateNotificationAccessFilter(Guid currentUserId)
        {
            return notification => notification.UserId == currentUserId;
        }
    }
}
