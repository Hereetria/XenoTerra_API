using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Auth.Payloads
{
    public record RegisterPayload : Payload<ResultAppUserOwnDto>;
}
