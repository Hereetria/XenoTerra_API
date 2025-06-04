using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Inputs
{
    public record CreatePostLikeAdminInput(
        string PostId,
        string UserId
    );
}
