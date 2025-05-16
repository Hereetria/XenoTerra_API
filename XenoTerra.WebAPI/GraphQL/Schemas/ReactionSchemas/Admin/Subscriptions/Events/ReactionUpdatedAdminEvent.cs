using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events
{
    public record ReactionUpdatedAdminEvent : UpdatedAdminEvent<ResultReactionDto>
    {
    }
}