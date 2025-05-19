using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices
{
    public interface IMessageWriteService : IWriteService<Message, CreateMessageDto, UpdateMessageDto, Guid> { }


}
