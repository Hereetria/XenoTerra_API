using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events
{
    public record CommentLikeOwnUpdatedEvent : UpdatedEvent<ResultCommentLikeOwnDto>
    {
    }
}
