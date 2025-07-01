using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events
{
    public record StoryAdminChangedEvent : ChangedEvent<ResultStoryAdminDto>
    {
    }
}