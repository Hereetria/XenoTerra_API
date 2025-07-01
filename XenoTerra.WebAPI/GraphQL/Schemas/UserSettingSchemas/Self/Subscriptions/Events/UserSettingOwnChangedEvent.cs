using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events
{
    public record UserSettingOwnChangedEvent : ChangedEvent<ResultUserSettingOwnDto>
    {
    }
}
