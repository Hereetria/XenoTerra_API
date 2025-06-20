using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.NotificationMutationServices
{
    public class NotificationOwnMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationOwnDto, CreateNotificationOwnDto, UpdateNotificationOwnDto, Guid>(mapper),
        INotificationOwnMutationService
    {
    }
}
