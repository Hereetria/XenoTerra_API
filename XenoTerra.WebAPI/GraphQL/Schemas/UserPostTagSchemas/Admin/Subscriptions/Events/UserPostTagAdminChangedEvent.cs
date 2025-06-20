using XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events
{
    public record UserPostTagAdminChangedEvent : ChangedEvent<ResultUserPostTagAdminDto>
    {
    }
}
