using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs
{
    public record CreateFollowAdminInput(
        string FollowerId,
        string FollowingId
    );
}
