using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NotificationResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries
{
    public class NotificationQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Notification, Guid> _queryResolver;

        public NotificationQuery(IMapper mapper, IQueryResolverHelper<Notification, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(NotificationFilterType))]
        [UseSorting(typeof(NotificationSortType))]
        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultNotificationWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(NotificationFilterType))]
        [UseSorting(typeof(NotificationSortType))]
        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetNotificationsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultNotificationWithRelationsDto>>(entities);
        }

        public async Task<ResultNotificationWithRelationsDto> GetNotificationByIdAsync(
            Guid key,
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultNotificationWithRelationsDto>(entity);
        }
    }


}
