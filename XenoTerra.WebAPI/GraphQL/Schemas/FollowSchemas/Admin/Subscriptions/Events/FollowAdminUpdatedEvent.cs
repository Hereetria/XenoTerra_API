using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events
{
    public record FollowAdminUpdatedEvent : UpdatedEvent<ResultFollowDto>
    {
    }
}
