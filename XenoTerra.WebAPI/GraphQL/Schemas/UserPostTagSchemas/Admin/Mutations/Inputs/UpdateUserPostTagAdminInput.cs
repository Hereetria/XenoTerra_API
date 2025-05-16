namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record UpdateUserPostTagAdminInput(
        string PostId,
        string UserId
    );
}
