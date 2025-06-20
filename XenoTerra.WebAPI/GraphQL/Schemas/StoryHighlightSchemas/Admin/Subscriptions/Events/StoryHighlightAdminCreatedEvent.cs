using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events
{
    public record StoryHighlightAdminCreatedEvent : CreatedEvent<ResultStoryHighlightAdminDto>
    {
    }
}