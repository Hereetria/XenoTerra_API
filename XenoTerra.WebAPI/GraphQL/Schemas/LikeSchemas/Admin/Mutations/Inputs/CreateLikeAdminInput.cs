using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs
{
    public record CreateLikeAdminInput(
        string PostId,
        string UserId
    );
}
