using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events
{
    public record FollowAdminCreatedEvent : CreatedEvent<ResultFollowAdminDto>
    {
    }
}
