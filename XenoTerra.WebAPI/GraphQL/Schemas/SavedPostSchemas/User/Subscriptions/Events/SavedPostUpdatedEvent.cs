using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events
{
    public record SavedPostUpdatedEvent : UpdatedEvent<ResultSavedPostDto>
    {
    }
}