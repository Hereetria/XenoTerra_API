using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events
{
    public record CommentSelfDeletedEvent : DeletedEvent<ResultCommentDto>
    {
    }
}
