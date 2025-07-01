using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events
{
    public record UserAdminChangedEvent : ChangedEvent<ResultAppUserAdminDto>
    {
    }
}
