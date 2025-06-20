using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Own
{

    public interface INotificationOwnWriteService : IWriteService<Notification, CreateNotificationOwnDto, UpdateNotificationOwnDto, Guid> { }

}
