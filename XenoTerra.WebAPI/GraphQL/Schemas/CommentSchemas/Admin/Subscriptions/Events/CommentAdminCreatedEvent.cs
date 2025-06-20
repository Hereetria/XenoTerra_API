using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events
{
    public record CommentAdminCreatedEvent : CreatedEvent<ResultCommentAdminDto>
    {
    }
}
