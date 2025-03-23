using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers
{
    public interface INotificationResolver : IEntityResolver<Notification, Guid>
    {
    }
}
