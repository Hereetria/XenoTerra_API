using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations.Inputs
{
    public record CreateLikeInput(
        string PostId,
        string UserId,
        [property: DateField] string LikedAt
    );
}
