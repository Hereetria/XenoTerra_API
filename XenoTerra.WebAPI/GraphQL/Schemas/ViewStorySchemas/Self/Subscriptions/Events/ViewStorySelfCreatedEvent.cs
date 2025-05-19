using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events
{
    public record ViewStorySelfCreatedEvent : CreatedEvent<ResultViewStoryDto>
    {
    }
}
