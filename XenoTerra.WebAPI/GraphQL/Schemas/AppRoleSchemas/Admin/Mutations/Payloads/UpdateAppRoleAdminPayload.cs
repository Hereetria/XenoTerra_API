using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads
{
    public record UpdateRoleAdminPayload : Payload<ResultAppRoleAdminDto>;
}
