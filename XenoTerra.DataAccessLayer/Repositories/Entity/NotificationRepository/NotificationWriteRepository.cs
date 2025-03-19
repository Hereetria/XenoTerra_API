using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NotificationRepository
{
    public class NotificationWriteRepository : WriteRepository<Notification, ResultNotificationDto, Guid>, INotificationWriteRepository
    {
        public NotificationWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }

}
