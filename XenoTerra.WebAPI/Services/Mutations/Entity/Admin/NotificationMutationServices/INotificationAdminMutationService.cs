using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NotificationMutationServices
{
    public interface INotificationAdminMutationService : IMutationService<Notification, ResultNotificationAdminDto, CreateNotificationAdminDto, UpdateNotificationAdminDto, Guid>
    {
    }
}