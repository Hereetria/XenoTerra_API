using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Payloads
{
    public record CreateReactionAdminPayload : Payload<ResultReactionAdminDto>;
}
