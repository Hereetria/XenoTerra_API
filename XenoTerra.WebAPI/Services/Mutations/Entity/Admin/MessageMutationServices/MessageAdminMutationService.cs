using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MessageMutationServices
{
    public class MessageAdminMutationService(IMapper mapper)
        : MutationService<Message, ResultMessageAdminDto, CreateMessageAdminDto, UpdateMessageAdminDto, Guid>(mapper),
        IMessageAdminMutationService
    {
    }
}