using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.NotificationQueries
{
    public class NotificationQuery
    {
        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetAllNotificationsAsync(
            [Service] INotificationReadService notificationReadService,
            [Service] NotificationResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = notificationReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Notification>().AsQueryable();

            var notifications = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(notifications, context);

            return mapper.Map<List<ResultNotificationWithRelationsDto>>(notifications);
        }

        public async Task<IEnumerable<ResultNotificationWithRelationsDto>> GetNotificationsByIdsAsync(
            [Service] INotificationReadService notificationReadService,
            [Service] NotificationResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = notificationReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Notification>().AsQueryable();

            var notifications = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(notifications, context);

            return mapper.Map<List<ResultNotificationWithRelationsDto>>(notifications);
        }

        public async Task<ResultNotificationWithRelationsDto> GetNotificationByIdAsync(
            [Service] INotificationReadService notificationReadService,
            [Service] NotificationResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = notificationReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Notification>().AsQueryable();

            var notification = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Notification with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(notification, context);

            return mapper.Map<ResultNotificationWithRelationsDto>(notification);
        }

    }
}
