using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events
{
    public record CommentLikeAdminCreatedEvent : CreatedEvent<ResultCommentLikeAdminDto>
    {
    }
}
