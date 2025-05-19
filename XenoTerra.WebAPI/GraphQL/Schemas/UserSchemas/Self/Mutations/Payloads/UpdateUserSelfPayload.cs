using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Mutations.Payloads
{
    public record UpdateUserSelfPayload : Payload<ResultUserPrivateDto>;
}
