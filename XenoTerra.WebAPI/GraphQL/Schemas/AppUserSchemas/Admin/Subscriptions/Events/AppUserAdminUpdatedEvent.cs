using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events
{
    public record UserAdminUpdatedEvent : UpdatedEvent<ResultAppUserPrivateDto>
    {
    }
}
