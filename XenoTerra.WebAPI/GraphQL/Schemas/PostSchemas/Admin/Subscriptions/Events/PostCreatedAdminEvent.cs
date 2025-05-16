using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events
{
    public record PostCreatedAdminEvent : CreatedAdminEvent<ResultPostDto>
    {
    }
}