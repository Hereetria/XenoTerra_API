using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events
{
    public record PostAdminUpdatedEvent : UpdatedEvent<ResultPostDto>
    {
    }
}