using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Auth.Payloads
{
    public record RegisterPayload : Payload<ResultAppUserPrivateDto>;
}
