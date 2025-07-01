using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events
{
    public record UserSettingAdminDeletedEvent : DeletedEvent<ResultUserSettingAdminDto>
    {
    }
}
