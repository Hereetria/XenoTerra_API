using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events
{
    public record StoryUpdatedEvent : UpdatedEvent<ResultStoryDto>
    {
    }
}