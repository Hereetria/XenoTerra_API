namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs
{
    public record UpdateRoleInput(
        string Id,
        string? Name
    );
}
