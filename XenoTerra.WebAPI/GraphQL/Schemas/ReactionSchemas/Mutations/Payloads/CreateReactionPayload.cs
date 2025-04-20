using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Payloads
{
    public record CreateReactionPayload : Payload<ResultReactionDto>;
}
