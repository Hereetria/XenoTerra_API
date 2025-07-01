using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.RecentChatsMutationServices
{
    public interface IRecentChatsOwnMutationService : IMutationService<RecentChats, ResultRecentChatsOwnDto, CreateRecentChatsOwnDto, UpdateRecentChatsOwnDto, Guid>
    {
    }
}
