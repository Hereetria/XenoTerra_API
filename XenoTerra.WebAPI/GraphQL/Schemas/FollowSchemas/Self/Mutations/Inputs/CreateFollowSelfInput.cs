using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs
{
    public record CreateFollowSelfInput(
        string FollowingId
    );
}
