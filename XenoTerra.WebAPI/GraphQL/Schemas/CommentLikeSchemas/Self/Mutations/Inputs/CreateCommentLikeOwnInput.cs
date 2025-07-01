using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Inputs
{
    public record CreateCommentLikeOwnInput(
        string CommentId
    );
}
