using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations.Payloads
{
    public record CreateUserPostTagPayload : Payload<ResultUserPostTagDto>;
}
