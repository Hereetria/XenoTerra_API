using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Write.Own
{
    public interface IMessageOwnWriteService : IWriteService<Message, CreateMessageOwnDto, UpdateMessageOwnDto, Guid> { }


}
