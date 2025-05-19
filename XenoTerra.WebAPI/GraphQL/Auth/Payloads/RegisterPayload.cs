using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Auth.Payloads
{
    public record RegisterPayload : Payload<ResultUserPrivateDto>;
}
