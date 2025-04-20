using AutoMapper;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.MessageMutationServices
{
    public class MessageMutationService(IMapper mapper)
        : MutationService<Message, ResultMessageDto, CreateMessageDto, UpdateMessageDto, Guid>(mapper),
        IMessageMutationService
    {
    }
}
