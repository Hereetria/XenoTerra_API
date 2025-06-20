using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Payloads
{
    public record CreateFollowAdminPayload : Payload<ResultFollowAdminDto>;
}
