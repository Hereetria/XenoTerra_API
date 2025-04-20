using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Payloads
{
    public record CreateHighlightPayload : Payload<ResultHighlightDto>;
}
