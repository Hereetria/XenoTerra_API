using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs
{
    public record UpdateFollowSelfInput(
        string FollowId,
        string? FollowingId
    );
}
