using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events
{
    public record StorySelfUpdatedEvent : UpdatedEvent<ResultStoryDto>
    {
    }
}