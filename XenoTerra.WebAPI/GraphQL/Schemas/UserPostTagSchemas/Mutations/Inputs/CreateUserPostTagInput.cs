namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations.Inputs
{
    public record CreateUserPostTagInput(
        string PostId,
        string UserId
    );
}
