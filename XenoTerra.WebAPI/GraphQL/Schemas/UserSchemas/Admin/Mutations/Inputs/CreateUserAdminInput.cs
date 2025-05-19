using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Inputs
{
    public record CreateUserAdminInput(
        string UserName,
        string Password,
        string ConfirmPassword,
        string Email,
        string FullName,
        [property: DateField] string BirthDate
    );
}
