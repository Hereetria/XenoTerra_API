using AutoMapper;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.RecentChatsMutationServices
{
    public class RecentChatsOwnMutationService(IMapper mapper)
        : MutationService<RecentChats, ResultRecentChatsOwnDto, CreateRecentChatsOwnDto, UpdateRecentChatsOwnDto, Guid>(mapper),
        IRecentChatsOwnMutationService
    {
    }
}
