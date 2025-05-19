using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events
{
    public record ViewStoryAdminUpdatedEvent : UpdatedEvent<ResultViewStoryDto>
    {
    }
}
