using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events
{
    public record FollowAdminChangedEvent : ChangedEvent<ResultFollowAdminDto>
    {
    }
}
