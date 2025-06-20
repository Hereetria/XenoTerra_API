using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events
{
    public record MessageAdminChangedEvent : ChangedEvent<ResultMessageAdminDto>
    {
    }
}
