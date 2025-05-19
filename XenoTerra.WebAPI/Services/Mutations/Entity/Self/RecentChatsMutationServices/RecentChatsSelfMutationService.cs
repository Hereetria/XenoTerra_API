using AutoMapper;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.RecentChatsMutationServices
{
    public class RecentChatsSelfMutationService(IMapper mapper)
        : MutationService<RecentChats, ResultRecentChatsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>(mapper),
        IRecentChatsSelfMutationService
    {
    }
}
