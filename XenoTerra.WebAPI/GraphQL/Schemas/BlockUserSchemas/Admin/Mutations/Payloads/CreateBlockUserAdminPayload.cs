using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Payloads
{
    public record CreateBlockUserAdminPayload: Payload<ResultBlockUserAdminDto>;
}
