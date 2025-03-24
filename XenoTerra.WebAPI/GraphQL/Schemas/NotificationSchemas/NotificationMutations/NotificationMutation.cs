using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationMutations
{
    public class NotificationMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Notification")]
        public async Task<ResultNotificationDto> CreateNotificationAsync(CreateNotificationDto createNotificationDto, [Service] INotificationWriteService notificationWriteService)
        {
            var result = await notificationWriteService.CreateAsync(createNotificationDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Notification")]
        public async Task<ResultNotificationDto> UpdateNotificationAsync(UpdateNotificationDto updateNotificationDto, [Service] INotificationWriteService notificationWriteService)
        {
            var result = await notificationWriteService.UpdateAsync(updateNotificationDto);
            return result;
        }

        [GraphQLDescription("Delete a Notification by ID")]
        public async Task<bool> DeleteNotificationAsync(Guid id, [Service] INotificationWriteService notificationWriteService)
        {
            var result = await notificationWriteService.DeleteAsync(id);
            return result;
        }
    }
}
