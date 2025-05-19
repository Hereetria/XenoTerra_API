using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events
{
    public record RecentChatsAdminUpdatedEvent : UpdatedEvent<ResultRecentChatsDto>
    {
    }
}