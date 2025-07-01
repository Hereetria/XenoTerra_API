using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events
{
    public record SavedPostOwnDeletedEvent : DeletedEvent<ResultSavedPostOwnDto>
    {
    }
}