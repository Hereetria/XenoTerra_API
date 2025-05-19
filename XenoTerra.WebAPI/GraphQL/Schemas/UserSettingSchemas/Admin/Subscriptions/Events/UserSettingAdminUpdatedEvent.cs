using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events
{
    public record UserSettingAdminUpdatedEvent : UpdatedEvent<ResultUserSettingDto>
    {
    }
}
