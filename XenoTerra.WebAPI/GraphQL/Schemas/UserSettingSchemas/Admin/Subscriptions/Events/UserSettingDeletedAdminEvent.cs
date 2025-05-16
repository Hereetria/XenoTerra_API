using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events
{
    public record UserSettingDeletedAdminEvent : DeletedAdminEvent<ResultUserSettingDto>
    {
    }
}
