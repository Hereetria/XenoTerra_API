using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RecentChatsMutationServices
{
    public interface IRecentChatsAdminMutationService : IMutationService<RecentChats, ResultRecentChatsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>
    {
    }
}
