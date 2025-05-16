using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs
{
    public record CreateCommentSelfInput(
        string Content,
        string PostId,
        string UserId
    );
}
