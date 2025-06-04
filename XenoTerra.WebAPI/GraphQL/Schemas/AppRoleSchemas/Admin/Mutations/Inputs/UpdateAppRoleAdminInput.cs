namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Inputs
{
    public record UpdateRoleAdminInput(
        string Id,
        string? Name
    );
}
