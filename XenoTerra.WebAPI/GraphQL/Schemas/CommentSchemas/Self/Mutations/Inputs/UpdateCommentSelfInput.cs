using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs
{
    public record UpdateCommentSelfInput(
        string CommentId,
        string? Content,
        string? PostId
    );
}
