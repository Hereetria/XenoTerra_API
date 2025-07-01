using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Payloads
{
    public record DeleteCommentOwnPayload : Payload<ResultCommentOwnDto>;
}
