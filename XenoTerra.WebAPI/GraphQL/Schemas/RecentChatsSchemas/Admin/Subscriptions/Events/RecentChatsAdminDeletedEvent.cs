using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events
{
    public record RecentChatsAdminDeletedEvent : DeletedEvent<ResultRecentChatsAdminDto>
    {
    }
}