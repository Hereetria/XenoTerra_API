using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads
{
    public record CreateUserAdminPayload : Payload<ResultAppUserPrivateDto>;
}
