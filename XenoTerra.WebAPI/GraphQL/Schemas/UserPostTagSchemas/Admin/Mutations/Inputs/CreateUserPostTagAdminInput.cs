namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record CreateUserPostTagAdminInput(
        string PostId,
        string UserId
    );
}
