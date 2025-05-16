namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs
{
    public record UpdateRoleAdminInput(
        string Id,
        string? Name
    );
}
