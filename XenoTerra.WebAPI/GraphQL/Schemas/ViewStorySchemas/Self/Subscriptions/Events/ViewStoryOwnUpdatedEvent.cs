using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events
{
    public record ViewStoryOwnUpdatedEvent : UpdatedEvent<ResultViewStoryOwnDto>
    {
    }
}
