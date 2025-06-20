using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events
{
    public record ReactionOwnCreatedEvent : CreatedEvent<ResultReactionOwnDto>
    {
    }
}