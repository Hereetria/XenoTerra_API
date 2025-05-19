using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events
{
    public record UserAdminChangedEvent : ChangedEvent<ResultUserPrivateDto>
    {
    }
}
