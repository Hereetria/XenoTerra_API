using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations.Inputs
{
    public record UpdateLikeSelfInput(
        string LikeId,
        string? PostId
    );
}
