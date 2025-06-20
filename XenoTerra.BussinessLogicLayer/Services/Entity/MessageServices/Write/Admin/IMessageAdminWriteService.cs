using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Write.Admin
{
    public interface IMessageAdminWriteService : IWriteService<Message, CreateMessageAdminDto, UpdateMessageAdminDto, Guid> { }


}
