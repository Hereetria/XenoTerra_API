using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads
{
    public record DeleteCommentLikeOwnPayload : Payload<ResultCommentLikeOwnDto>;
}
