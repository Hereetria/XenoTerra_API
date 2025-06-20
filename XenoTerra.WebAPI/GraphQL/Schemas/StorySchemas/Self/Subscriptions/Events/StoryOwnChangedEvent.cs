using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events
{
    public record StoryOwnChangedEvent : ChangedEvent<ResultStoryOwnDto>
    {
    }
}