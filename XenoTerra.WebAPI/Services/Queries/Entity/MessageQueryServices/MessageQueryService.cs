using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices
{
    public class MessageQueryService : QueryService<Message, ResultMessageWithRelationsDto, Guid>, IMessageQueryService
    {
        public MessageQueryService(IReadService<Message, ResultMessageWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}
