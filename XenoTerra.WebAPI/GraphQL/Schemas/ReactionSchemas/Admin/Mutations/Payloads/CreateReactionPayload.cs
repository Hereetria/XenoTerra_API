using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Payloads
{
    public record CreateReactionPayload : Payload<ResultReactionDto>;
}
