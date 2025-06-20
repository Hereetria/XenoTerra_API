using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Payloads
{
    public record DeleteCommentOwnPayload : Payload<ResultCommentOwnDto>;
}
