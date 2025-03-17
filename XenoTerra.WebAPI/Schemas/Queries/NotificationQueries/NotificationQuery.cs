using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.NotificationQueries
{
    public class NotificationQuery
    {
        private readonly IMapper _mapper;

        public NotificationQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetAllNotificationsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IResolverContext context)
        {
            var notifications = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(notifications, context);
            var notificationDtos = _mapper.Map<List<ResultNotificationWithRelationsDto>>(notifications);
            return notificationDtos;
        }

        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetNotificationsByIdsAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var notifications = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(notifications, context);
            var notificationDtos = _mapper.Map<List<ResultNotificationWithRelationsDto>>(notifications);
            return notificationDtos;
        }

        public async Task<ResultNotificationWithRelationsDto> GetNotificationByIdAsync(
            [Service] INotificationQueryService service,
            [Service] INotificationResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var notification = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(notification, context);
            var notificationDto = _mapper.Map<ResultNotificationWithRelationsDto>(notification);
            return notificationDto;
        }
    }

}
