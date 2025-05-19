using AutoMapper;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RecentChatsMutationServices
{
    public class RecentChatsAdminMutationService(IMapper mapper)
        : MutationService<RecentChats, ResultRecentChatsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>(mapper),
        IRecentChatsAdminMutationService
    {
    }
}
