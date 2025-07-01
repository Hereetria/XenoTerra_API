using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RecentChatsMutationServices
{
    public class RecentChatsAdminMutationService(IMapper mapper)
        : MutationService<RecentChats, ResultRecentChatsAdminDto, CreateRecentChatsAdminDto, UpdateRecentChatsAdminDto, Guid>(mapper),
        IRecentChatsAdminMutationService
    {
    }
}