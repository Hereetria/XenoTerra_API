using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs
{
    public record UpdateFollowOwnInput(
        string FollowId,
        string? FollowingId
    );
}
