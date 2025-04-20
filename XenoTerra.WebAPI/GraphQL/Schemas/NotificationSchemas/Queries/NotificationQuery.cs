using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries
{
    public class NotificationQuery(IMapper mapper, IQueryResolverHelper<Notification, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Notification, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationFilterType))]
        [UseSorting(typeof(NotificationSortType))]
        public async Task<NotificationConnection> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationConnection, ResultNotificationWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NotificationFilterType))]
        [UseSorting(typeof(NotificationSortType))]
        public async Task<NotificationConnection> GetNotificationsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Notification, ResultNotificationWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NotificationConnection, ResultNotificationWithRelationsDto>(connection);
        }

        public async Task<ResultNotificationWithRelationsDto?> GetNotificationByIdAsync(
            string? key,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultNotificationWithRelationsDto>(entity);
        }
    }
}
