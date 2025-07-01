using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Payloads
{
    public record DeleteReactionAdminPayload : Payload<ResultReactionAdminDto>;
}
