using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Admin
{

    public interface INotificationAdminWriteService : IWriteService<Notification, CreateNotificationAdminDto, UpdateNotificationAdminDto, Guid> { }

}
