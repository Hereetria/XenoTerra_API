using AutoMapper;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.MessageMutationServices
{
    public class MessageOwnMutationService(IMapper mapper)
        : MutationService<Message, ResultMessageOwnDto, CreateMessageOwnDto, UpdateMessageOwnDto, Guid>(mapper),
        IMessageOwnMutationService
    {
    }
}
