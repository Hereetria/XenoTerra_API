using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService
{
    public class NotificationReadService : ReadService<Notification, ResultNotificationWithRelationsDto, Guid>, INotificationReadService
    {
        public NotificationReadService(IReadRepository<Notification, ResultNotificationWithRelationsDto, Guid> repository)
            : base(repository) { }
    }
}
