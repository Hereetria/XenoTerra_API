using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Inputs
{
    public record CreateCommentLikeAdminInput(
        string PostId,
        string UserId
    );
}
