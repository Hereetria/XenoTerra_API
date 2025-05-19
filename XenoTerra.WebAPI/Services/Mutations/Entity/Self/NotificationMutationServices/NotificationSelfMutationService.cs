using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.NotificationMutationServices
{
    public class NotificationSelfMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>(mapper),
        INotificationSelfMutationService
    {
    }
}
