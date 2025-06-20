using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RecentChatsMutationServices
{
    public interface IRecentChatsAdminMutationService : IMutationService<RecentChats, ResultRecentChatsAdminDto, CreateRecentChatsAdminDto, UpdateRecentChatsAdminDto, Guid>
    {
    }
}