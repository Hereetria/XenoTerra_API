using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs
{
    public record CreateCommentSelfInput(
        string Content,
        string PostId
    );
}
