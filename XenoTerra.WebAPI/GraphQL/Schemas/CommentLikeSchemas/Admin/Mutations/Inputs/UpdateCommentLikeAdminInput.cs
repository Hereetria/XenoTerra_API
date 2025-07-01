using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Inputs
{
    public record UpdateCommentLikeAdminInput(
        string CommentLikeId,
        string? CommentId,
        string? UserId
    );
}
