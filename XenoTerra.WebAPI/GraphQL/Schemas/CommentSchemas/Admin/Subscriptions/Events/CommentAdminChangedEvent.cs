using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events
{
    public record CommentAdminChangedEvent : ChangedEvent<ResultCommentAdminDto>
    {
    }
}
