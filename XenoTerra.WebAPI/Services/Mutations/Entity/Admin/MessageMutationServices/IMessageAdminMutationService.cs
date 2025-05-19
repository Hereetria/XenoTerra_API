using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MessageMutationServices
{
    public interface IMessageAdminMutationService : IMutationService<Message, ResultMessageDto, CreateMessageDto, UpdateMessageDto, Guid>
    {
    }
}
