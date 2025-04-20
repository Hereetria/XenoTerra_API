namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Inputs
{
    public record UpdateRoleInput(
        string Id,
        string? Name
    );
}
