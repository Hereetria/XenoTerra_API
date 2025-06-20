using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs
{
    public record CreateCommentOwnInput(
        string Content,
        string PostId,
        string? ParentCommentId
    );
}
