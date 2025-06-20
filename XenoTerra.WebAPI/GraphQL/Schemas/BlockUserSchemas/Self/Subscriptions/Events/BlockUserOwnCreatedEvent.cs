using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events
{
    public record BlockUserOwnCreatedEvent : CreatedEvent<ResultBlockUserOwnDto>
    {
    }
}
