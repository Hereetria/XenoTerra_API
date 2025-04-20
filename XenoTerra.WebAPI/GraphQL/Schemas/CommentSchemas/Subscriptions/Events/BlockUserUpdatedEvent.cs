using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions.Events
{
    public record CommentUpdatedEvent : UpdatedEvent<ResultCommentDto>
    {
    }
}
