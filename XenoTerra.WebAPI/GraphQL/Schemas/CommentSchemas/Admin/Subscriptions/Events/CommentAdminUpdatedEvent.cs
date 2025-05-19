using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events
{
    public record CommentAdminUpdatedEvent : UpdatedEvent<ResultCommentDto>
    {
    }
}
