using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Payloads
{
    public record CreateUserSelfPayload : Payload<ResultUserDto>;
}
