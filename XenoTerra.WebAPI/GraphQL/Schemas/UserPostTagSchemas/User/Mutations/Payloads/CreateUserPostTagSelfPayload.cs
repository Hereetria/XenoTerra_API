using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Payloads
{
    public record CreateUserPostTagSelfPayload : Payload<ResultUserPostTagDto>;
}
