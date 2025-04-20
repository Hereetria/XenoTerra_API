using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.NotificationMutationServices
{
    public class NotificationMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>(mapper),
        INotificationMutationService
    {
    }
}
