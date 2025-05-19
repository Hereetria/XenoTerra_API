using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Payloads
{
    public record DeleteCommentSelfPayload : Payload<ResultCommentDto>;
}
