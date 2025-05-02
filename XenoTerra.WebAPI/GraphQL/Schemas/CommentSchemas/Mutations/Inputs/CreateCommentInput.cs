using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Inputs
{
    public record CreateCommentInput(
        string Content,
        string PostId,
        string UserId
    );
}
