using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MessageService
{
    public class MessageReadService : ReadService<Message, ResultMessageWithRelationsDto, Guid>, IMessageReadService
    {
        public MessageReadService(IReadRepository<Message, ResultMessageWithRelationsDto, Guid> repository, IMapper mapper)
            : base(repository) { }
    }

}
