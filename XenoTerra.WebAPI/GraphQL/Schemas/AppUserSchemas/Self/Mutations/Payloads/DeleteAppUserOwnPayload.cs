using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads
{
    public record DeleteUserOwnPayload : Payload<ResultAppUserOwnDto>;
}
