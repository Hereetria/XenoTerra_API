namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs
{
    public record UpdateRoleSelfInput(
        string Id,
        string? Name
    );
}
