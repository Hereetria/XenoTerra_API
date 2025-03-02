using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Notification
{
    public class NotificationMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Notification")]
        public async Task<ResultNotificationByIdDto> CreateNotificationAsync(CreateNotificationDto createNotificationDto, [Service] INotificationServiceBLL notificationServiceBLL)
        {
            var result = await notificationServiceBLL.CreateAsync(createNotificationDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Notification")]
        public async Task<ResultNotificationByIdDto> UpdateNotificationAsync(UpdateNotificationDto updateNotificationDto, [Service] INotificationServiceBLL notificationServiceBLL)
        {
            var result = await notificationServiceBLL.UpdateAsync(updateNotificationDto);
            return result;
        }

        [GraphQLDescription("Delete a Notification by ID")]
        public async Task<bool> DeleteNotificationAsync(Guid id, [Service] INotificationServiceBLL notificationServiceBLL)
        {
            var result = await notificationServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
