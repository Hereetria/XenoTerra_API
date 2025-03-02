using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Notification
{
    public class NotificationQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Notifications")]
        public IQueryable<ResultNotificationDto> GetAllNotifications([Service] INotificationServiceBLL notificationServiceBLL)
        {
            return notificationServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get Notification by ID")]
        public IQueryable<ResultNotificationByIdDto> GetNotificationById(Guid id, [Service] INotificationServiceBLL notificationServiceBLL)
        {
            var result = notificationServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"Notification with ID {id} not found");
            }
            return result;
        }
    }
}
