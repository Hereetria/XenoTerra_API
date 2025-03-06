
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.NotificationServices
{
    
    public interface INotificationServiceDAL : IGenericRepositoryDAL<Notification, ResultNotificationDto, ResultNotificationWithRelationsDto, CreateNotificationDto, UpdateNotificationDto, Guid>

    {

    }
}