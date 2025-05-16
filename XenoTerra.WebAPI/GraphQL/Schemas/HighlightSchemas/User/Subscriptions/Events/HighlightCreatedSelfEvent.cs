using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events
{
    public record HighlightCreatedSelfEvent : CreatedSelfEvent<ResultHighlightDto>
    {
    }
}
