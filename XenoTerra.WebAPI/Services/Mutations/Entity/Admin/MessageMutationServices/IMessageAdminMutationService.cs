using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MessageMutationServices
{
    public interface IMessageAdminMutationService : IMutationService<Message, ResultMessageAdminDto, CreateMessageAdminDto, UpdateMessageAdminDto, Guid>
    {
    }
}