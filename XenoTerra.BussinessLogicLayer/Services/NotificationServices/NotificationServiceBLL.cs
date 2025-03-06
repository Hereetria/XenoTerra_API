
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.NotificationServices
{
     public class NotificationServiceBLL : GenericRepositoryBLL<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>, INotificationServiceBLL
    {
        public NotificationServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}