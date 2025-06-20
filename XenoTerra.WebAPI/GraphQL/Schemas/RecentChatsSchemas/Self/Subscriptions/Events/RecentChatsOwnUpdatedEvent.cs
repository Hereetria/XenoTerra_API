using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events
{
    public record RecentChatsOwnUpdatedEvent : UpdatedEvent<ResultRecentChatsOwnDto>
    {
    }
}