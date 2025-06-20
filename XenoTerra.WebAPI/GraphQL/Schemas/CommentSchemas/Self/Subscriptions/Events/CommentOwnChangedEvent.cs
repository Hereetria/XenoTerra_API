using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events
{
    public record CommentOwnChangedEvent : ChangedEvent<ResultCommentOwnDto>
    {
    }
}
