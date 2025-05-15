using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events
{
    public record CommentCreatedEvent : CreatedEvent<ResultCommentDto>
    {
    }
}
