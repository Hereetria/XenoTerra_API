namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record CreateUserPostTagInput(
        string PostId,
        string UserId
    );
}
