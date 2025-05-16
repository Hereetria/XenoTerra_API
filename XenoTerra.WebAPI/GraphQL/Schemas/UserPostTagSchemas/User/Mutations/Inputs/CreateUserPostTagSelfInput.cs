namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record CreateUserPostTagSelfInput(
        string PostId,
        string UserId
    );
}
