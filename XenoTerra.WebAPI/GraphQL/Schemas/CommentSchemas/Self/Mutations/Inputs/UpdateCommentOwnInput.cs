using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs
{
    public record UpdateCommentOwnInput(
        string CommentId,
        string? Content,
        string? PostId,
        string? ParentCommentId
    );
}
