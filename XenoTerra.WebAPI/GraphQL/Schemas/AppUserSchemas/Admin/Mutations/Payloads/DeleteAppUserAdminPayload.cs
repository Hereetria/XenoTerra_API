using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads
{
    public record DeleteUserAdminPayload : Payload<ResultAppUserAdminDto>;
}
