using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events
{
    public record BlockUserAdminUpdatedEvent : UpdatedEvent<ResultBlockUserAdminDto>
    {
    }
}
