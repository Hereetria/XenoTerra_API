using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Payloads
{
    public record DeleteCommentLikeAdminPayload : Payload<ResultCommentLikeAdminDto>;
}
