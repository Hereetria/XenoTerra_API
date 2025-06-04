using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads
{
    public record UpdateUserSelfPayload : Payload<ResultAppUserPrivateDto>;
}
