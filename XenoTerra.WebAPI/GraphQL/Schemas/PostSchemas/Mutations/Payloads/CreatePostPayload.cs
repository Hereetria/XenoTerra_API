using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Mutations.Payloads
{
    public record CreatePostPayload : Payload<ResultPostDto>;
}
