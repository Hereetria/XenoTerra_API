using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events
{
    public record MediaDeletedAdminEvent : DeletedAdminEvent<ResultMediaDto>
    {
    }
}
