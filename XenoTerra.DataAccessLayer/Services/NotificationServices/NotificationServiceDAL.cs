

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.NotificationServices
{
    
    public class NotificationServiceDAL : GenericRepositoryDAL<Notification, ResultNotificationDto, ResultNotificationWithRelationsDto, CreateNotificationDto, UpdateNotificationDto, Guid>, INotificationServiceDAL

    {

        public NotificationServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}