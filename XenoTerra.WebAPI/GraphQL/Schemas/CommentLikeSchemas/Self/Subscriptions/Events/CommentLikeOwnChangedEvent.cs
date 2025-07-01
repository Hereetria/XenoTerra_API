using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events
{
    public record CommentLikeOwnChangedEvent : ChangedEvent<ResultCommentLikeOwnDto>
    {
    }
}
