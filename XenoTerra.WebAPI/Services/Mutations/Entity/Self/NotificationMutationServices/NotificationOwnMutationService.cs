using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.NotificationMutationServices
{
    public class NotificationOwnMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationOwnDto, CreateNotificationOwnDto, UpdateNotificationOwnDto, Guid>(mapper),
        INotificationOwnMutationService
    {
    }
}
