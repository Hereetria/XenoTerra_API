using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events
{
    public record CommentLikeSelfCreatedEvent : CreatedEvent<ResultCommentLikeDto>
    {
    }
}
