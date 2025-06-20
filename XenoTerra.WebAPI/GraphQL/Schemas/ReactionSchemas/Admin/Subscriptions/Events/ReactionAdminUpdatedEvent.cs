using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events
{
    public record ReactionAdminUpdatedEvent : UpdatedEvent<ResultReactionAdminDto>
    {
    }
}