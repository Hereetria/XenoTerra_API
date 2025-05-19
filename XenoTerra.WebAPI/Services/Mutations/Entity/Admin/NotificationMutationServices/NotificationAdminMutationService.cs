using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NotificationMutationServices
{
    public class NotificationAdminMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>(mapper),
        INotificationAdminMutationService
    {
    }
}
