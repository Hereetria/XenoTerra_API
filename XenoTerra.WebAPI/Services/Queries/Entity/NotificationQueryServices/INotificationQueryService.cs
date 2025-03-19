using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices
{
    public interface INotificationQueryService : IQueryService<Notification, ResultNotificationWithRelationsDto, Guid>
    {
    }
}
