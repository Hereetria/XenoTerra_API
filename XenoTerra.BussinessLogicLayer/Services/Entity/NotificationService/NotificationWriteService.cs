using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService
{
    public class NotificationWriteService : WriteService<Notification, ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto, Guid>, INotificationWriteService
    {
        public NotificationWriteService(IWriteRepository<Notification, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
