using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events
{
    public record FollowUpdatedAdminEvent : UpdatedAdminEvent<ResultFollowDto>
    {
    }
}
