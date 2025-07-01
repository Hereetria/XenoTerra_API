using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events
{
    public record ReactionAdminDeletedEvent : DeletedEvent<ResultReactionAdminDto>
    {
    }
}