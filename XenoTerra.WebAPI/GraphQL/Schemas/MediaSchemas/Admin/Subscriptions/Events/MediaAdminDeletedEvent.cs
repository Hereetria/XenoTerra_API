using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events
{
    public record MediaAdminDeletedEvent : DeletedEvent<ResultMediaDto>
    {
    }
}
