using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events
{
    public record StoryHighlightAdminUpdatedEvent : UpdatedEvent<ResultStoryHighlightAdminDto>
    {
    }
}