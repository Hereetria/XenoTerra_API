using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Subscriptions.Events
{
    public record ReactionUpdatedEvent : UpdatedEvent<ResultReactionDto>
    {
    }
}