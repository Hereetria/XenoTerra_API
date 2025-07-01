using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events
{
    public record CommentOwnUpdatedEvent : UpdatedEvent<ResultCommentOwnDto>
    {
    }
}
