using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events
{
    public record CommentLikeAdminDeletedEvent : DeletedEvent<ResultCommentLikeAdminDto>
    {
    }
}
