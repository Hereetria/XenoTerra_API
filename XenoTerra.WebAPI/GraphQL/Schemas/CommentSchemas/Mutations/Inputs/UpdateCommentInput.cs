using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Inputs
{
    public record UpdateCommentInput(
        string CommentId,
        string? Content,
        string? PostId,
        string? UserId,
        [property: DateField] string? CommentedAt
    );
}
