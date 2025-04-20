using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations.Inputs
{
    public record CreateFollowInput(
        string FollowerId,
        string FollowingId,
        [property: DateField] string FollowedAt
    );
}
