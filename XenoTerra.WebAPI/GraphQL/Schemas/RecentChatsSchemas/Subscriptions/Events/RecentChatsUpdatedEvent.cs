using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Subscriptions.Events
{
    public record RecentChatsUpdatedEvent : UpdatedEvent<ResultRecentChatsDto>
    {
    }
}