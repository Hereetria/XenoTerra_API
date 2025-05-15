using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs
{
    public record UpdateFollowInput(
        string FollowId,
        string? FollowerId,
        string? FollowingId
    );
}
