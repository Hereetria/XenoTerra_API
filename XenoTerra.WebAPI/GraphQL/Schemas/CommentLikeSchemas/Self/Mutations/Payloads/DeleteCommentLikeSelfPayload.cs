using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads
{
    public record DeleteCommentLikeSelfPayload : Payload<ResultCommentLikeDto>;
}
