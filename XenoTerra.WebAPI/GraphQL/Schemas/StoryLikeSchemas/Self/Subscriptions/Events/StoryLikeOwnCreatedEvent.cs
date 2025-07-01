using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events
{
    public record StoryLikeOwnCreatedEvent : CreatedEvent<ResultStoryLikeOwnDto>
    {
    }
}
