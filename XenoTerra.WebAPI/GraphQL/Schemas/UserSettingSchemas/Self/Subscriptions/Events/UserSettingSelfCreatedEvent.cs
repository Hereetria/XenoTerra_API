using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events
{
    public record UserSettingSelfCreatedEvent : CreatedEvent<ResultUserSettingDto>
    {
    }
}
