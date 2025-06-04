using XenoTerra.DTOLayer.Dtos.AppRoleDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads
{
    public record CreateRoleAdminPayload : Payload<ResultAppRoleDto>;
}
