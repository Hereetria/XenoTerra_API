using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs
{
    public record UpdatePostLikeOwnInput(
        string LikeId,
        string? PostId
    );
}
