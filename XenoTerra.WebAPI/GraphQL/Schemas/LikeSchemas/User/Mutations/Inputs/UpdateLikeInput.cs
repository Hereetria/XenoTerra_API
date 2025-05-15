using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs
{
    public record UpdateLikeInput(
        string LikeId,
        string? PostId,
        string? UserId
    );
}
