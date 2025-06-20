using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events
{
    public record UserSettingAdminCreatedEvent : CreatedEvent<ResultUserSettingAdminDto>
    {
    }
}
