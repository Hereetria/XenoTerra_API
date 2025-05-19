using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads
{
    public record DeleteUserAdminPayload : Payload<ResultUserPrivateDto>;
}
