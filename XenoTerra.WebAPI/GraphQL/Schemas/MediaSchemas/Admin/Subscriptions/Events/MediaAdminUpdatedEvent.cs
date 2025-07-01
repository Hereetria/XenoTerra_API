using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events
{
    public record MediaAdminUpdatedEvent : UpdatedEvent<ResultMediaAdminDto>
    {
    }
}
