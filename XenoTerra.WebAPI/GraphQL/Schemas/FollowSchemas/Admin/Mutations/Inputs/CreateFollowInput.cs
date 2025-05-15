using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs
{
    public record CreateFollowInput(
        string FollowerId,
        string FollowingId
    );
}
