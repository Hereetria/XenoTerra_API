using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NotificationResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class NotificationAdminQuery(IMapper mapper, IQueryResolverHelper<Notification, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Notification, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationAdminFilterType))]
        [UseSorting(typeof(NotificationAdminSortType))]
        public async Task<NotificationAdminConnection> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationAdminConnection, ResultNotificationWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationAdminFilterType))]
        [UseSorting(typeof(NotificationAdminSortType))]
        public async Task<NotificationAdminConnection> GetNotificationsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationAdminConnection, ResultNotificationWithRelationsAdminDto>(connection);
        }

        public async Task<ResultNotificationWithRelationsAdminDto?> GetNotificationByIdAsync(
            string? key,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNotificationWithRelationsAdminDto>(entity);
        }
    }
}
