using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs
{
    public record UpdatePostLikeSelfInput(
        string LikeId,
        string? PostId
    );
}
