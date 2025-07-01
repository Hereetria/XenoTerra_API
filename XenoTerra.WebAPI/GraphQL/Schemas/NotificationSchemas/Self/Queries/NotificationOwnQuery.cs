using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NotificationResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Filters;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NotificationOwnQuery(IMapper mapper, IQueryResolverHelper<Notification, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Notification, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationOwnFilterType))]
        [UseSorting(typeof(NotificationOwnSortType))]
        public async Task<NotificationOwnConnection> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateNotificationAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationOwnConnection, ResultNotificationWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationOwnFilterType))]
        [UseSorting(typeof(NotificationOwnSortType))]
        public async Task<NotificationOwnConnection> GetNotificationsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateNotificationAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationOwnConnection, ResultNotificationWithRelationsOwnDto>(connection);
        }

        public async Task<ResultNotificationWithRelationsOwnDto?> GetNotificationByIdAsync(
            string? key,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateNotificationAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNotificationWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Notification, bool>> CreateNotificationAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Notification, Guid>(
                n => n.UserId,
                currentUserId
            );
        }
    }
}
