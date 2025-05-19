using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events
{
    public record StoryHighlightAdminUpdatedEvent : UpdatedEvent<ResultStoryHighlightDto>
    {
    }
}