using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events
{
    public record ReactionAdminCreatedEvent : CreatedEvent<ResultReactionDto>
    {
    }
}