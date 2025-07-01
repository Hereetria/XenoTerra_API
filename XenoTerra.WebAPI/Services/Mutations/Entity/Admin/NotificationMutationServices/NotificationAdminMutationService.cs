using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NotificationMutationServices
{
    public class NotificationAdminMutationService(IMapper mapper)
        : MutationService<Notification, ResultNotificationAdminDto, CreateNotificationAdminDto, UpdateNotificationAdminDto, Guid>(mapper),
        INotificationAdminMutationService
    {
    }
}