using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Payloads
{
    public record UpdateCommentLikeAdminPayload : Payload<ResultCommentLikeDto>;
}
