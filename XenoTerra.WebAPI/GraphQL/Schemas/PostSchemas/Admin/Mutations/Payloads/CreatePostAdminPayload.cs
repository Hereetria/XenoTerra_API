using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads
{
    public record CreatePostAdminPayload : Payload<ResultPostAdminDto>;
}
