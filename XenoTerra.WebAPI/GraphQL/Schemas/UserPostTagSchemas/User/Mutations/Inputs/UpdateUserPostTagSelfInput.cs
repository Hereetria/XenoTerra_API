namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record UpdateUserPostTagSelfInput(
        string PostId,
        string UserId
    );
}
