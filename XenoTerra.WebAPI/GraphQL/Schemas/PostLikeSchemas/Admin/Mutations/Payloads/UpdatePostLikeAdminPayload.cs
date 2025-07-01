using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Payloads
{
    public record UpdatePostLikeAdminPayload : Payload<ResultPostLikeAdminDto>;
}
