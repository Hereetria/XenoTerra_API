using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.NotificationMutationServices
{
    public interface INotificationMutationService : IMutationService<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>
    {
    }
}
