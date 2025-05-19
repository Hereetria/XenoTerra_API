using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events
{
    public record SavedPostSelfUpdatedEvent : UpdatedEvent<ResultSavedPostDto>
    {
    }
}