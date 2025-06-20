using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events
{
    public record MediaAdminDeletedEvent : DeletedEvent<ResultMediaAdminDto>
    {
    }
}
