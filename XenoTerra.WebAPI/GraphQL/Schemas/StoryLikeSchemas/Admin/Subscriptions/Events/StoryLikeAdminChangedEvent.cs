using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events
{
    public record StoryLikeAdminChangedEvent : ChangedEvent<ResultStoryLikeAdminDto>
    {
    }
}
