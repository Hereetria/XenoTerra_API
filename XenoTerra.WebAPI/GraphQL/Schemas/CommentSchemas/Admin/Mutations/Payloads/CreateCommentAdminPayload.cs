using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads
{
    public record CreateCommentAdminPayload : Payload<ResultCommentAdminDto>;
}
