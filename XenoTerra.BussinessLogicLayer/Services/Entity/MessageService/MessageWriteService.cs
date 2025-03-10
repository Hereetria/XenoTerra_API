using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageService
{
    public class MessageWriteService : WriteService<Message, ResultMessageDto, CreateMessageDto, UpdateMessageDto, Guid>, IMessageWriteService
    {
        public MessageWriteService(IWriteRepository<Message, Guid> repository, IMapper mapper, SelectorExpressionProvider<Message, ResultMessageDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }

}
