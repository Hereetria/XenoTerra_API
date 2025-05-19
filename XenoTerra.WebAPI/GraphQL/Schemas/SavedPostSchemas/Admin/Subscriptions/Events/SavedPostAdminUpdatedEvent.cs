using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events
{
    public record SavedPostAdminUpdatedEvent : UpdatedEvent<ResultSavedPostDto>
    {
    }
}