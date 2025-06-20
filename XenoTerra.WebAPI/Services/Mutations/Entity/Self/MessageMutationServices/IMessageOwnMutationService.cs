using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.MessageMutationServices
{
    public interface IMessageOwnMutationService : IMutationService<Message, ResultMessageOwnDto, CreateMessageOwnDto, UpdateMessageOwnDto, Guid>
    {
    }
}
