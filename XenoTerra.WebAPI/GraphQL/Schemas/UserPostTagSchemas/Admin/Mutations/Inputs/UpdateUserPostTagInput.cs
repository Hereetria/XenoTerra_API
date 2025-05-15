namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs
{
    public record UpdateUserPostTagInput(
        string PostId,
        string UserId
    );
}
