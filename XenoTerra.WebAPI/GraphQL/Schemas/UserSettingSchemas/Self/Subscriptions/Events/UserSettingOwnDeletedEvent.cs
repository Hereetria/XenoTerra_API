using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events
{
    public record UserSettingOwnDeletedEvent : DeletedEvent<ResultUserSettingOwnDto>
    {
    }
}
