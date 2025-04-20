using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events
{
    public record ViewStoryCreatedEvent : CreatedEvent<ResultViewStoryDto>
    {
    }
}
