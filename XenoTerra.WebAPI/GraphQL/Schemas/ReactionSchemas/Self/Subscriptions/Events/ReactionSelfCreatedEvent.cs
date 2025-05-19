using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events
{
    public record ReactionSelfCreatedEvent : CreatedEvent<ResultReactionDto>
    {
    }
}