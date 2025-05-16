using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events
{
    public record StoryHighlightUpdatedAdminEvent : UpdatedAdminEvent<ResultStoryHighlightDto>
    {
    }
}