using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Payloads
{
    public record DeleteCommentPayload : Payload<ResultCommentDto>;
}
