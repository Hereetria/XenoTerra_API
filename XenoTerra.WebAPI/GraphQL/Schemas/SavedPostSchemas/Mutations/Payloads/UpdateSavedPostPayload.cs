using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Payloads
{
    public record UpdateSavedPostPayload : Payload<ResultSavedPostDto>;
}
