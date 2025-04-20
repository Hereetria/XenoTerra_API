namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations.Inputs
{
    public record UpdateUserPostTagInput(
        string PostId,
        string? UserId
    );
}
