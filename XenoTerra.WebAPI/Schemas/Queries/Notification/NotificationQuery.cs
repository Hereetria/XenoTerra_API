using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Notification
{
    public class NotificationQuery
    {
        [UseProjection]
        public IQueryable<ResultNotificationDto> GetNotifications(List<Guid>? ids, [Service] INotificationServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
        //[UseProjection]
        //[GraphQLDescription("Get all Notifications")]
        //public IQueryable<ResultNotificationDto> GetAllNotifications([Service] INotificationServiceBLL notificationServiceBLL)
        //{
        //    return notificationServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Notification by ID")]
        //public IQueryable<ResultNotificationByIdDto> GetNotificationById(Guid id, [Service] INotificationServiceBLL notificationServiceBLL)
        //{
        //    var result = notificationServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Notification with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
