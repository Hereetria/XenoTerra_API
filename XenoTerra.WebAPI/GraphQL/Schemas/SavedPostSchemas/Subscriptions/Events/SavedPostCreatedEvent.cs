using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Subscriptions.Events
{
    public record SavedPostCreatedEvent : CreatedEvent<ResultSavedPostDto>
    {
    }
}