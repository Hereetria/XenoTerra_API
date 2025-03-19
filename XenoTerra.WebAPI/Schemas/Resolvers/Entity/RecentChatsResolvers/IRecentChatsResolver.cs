using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers
{
    public interface IRecentChatsResolver : IEntityResolver<RecentChats, ResultRecentChatsWithRelationsDto, Guid>
    {
    }
}
