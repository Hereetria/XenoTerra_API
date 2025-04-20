using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Subscriptions.Events
{
    public record StoryHighlightUpdatedEvent : UpdatedEvent<ResultStoryHighlightDto>
    {
    }
}