using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events
{
    public record StoryOwnUpdatedEvent : UpdatedEvent<ResultStoryOwnDto>
    {
    }
}