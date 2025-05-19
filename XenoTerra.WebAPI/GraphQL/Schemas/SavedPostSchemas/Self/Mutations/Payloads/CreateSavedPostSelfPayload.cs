using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Payloads
{
    public record CreateSavedPostSelfPayload : Payload<ResultSavedPostDto>;
}
