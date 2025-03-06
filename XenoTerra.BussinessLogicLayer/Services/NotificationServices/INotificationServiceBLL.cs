
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.NotificationServices
{
        public interface INotificationServiceBLL : IGenericRepositoryBLL<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>
    {

    }
}