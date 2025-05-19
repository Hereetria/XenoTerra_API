using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.MessageMutationServices
{
    public interface IMessageSelfMutationService : IMutationService<Message, ResultMessageDto, CreateMessageDto, UpdateMessageDto, Guid>
    {
    }
}
