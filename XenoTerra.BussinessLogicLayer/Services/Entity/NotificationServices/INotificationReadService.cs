using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices
{

    public interface INotificationReadService : IReadService<Notification, Guid> { }

}
