using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events
{
    public record RecentChatsSelfDeletedEvent : DeletedEvent<ResultRecentChatsDto>
    {
    }
}