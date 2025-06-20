using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events
{
    public record UserAdminUpdatedEvent : UpdatedEvent<ResultAppUserOwnDto>
    {
    }
}
