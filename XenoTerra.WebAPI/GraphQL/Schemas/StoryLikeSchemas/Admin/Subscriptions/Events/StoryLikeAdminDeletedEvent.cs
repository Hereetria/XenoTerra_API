using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events
{
    public record StoryLikeAdminDeletedEvent : DeletedEvent<ResultStoryLikeAdminDto>
    {
    }
}
