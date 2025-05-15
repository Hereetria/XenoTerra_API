using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs
{
    public record CreateLikeInput(
        string PostId,
        string UserId
    );
}
