using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Inputs
{
    public record CreateUserInput(
        string UserName,
        string Password,
        string ConfirmPassword,
        string Email,
        string FullName,
        [property: DateField] string BirthDate
    );
}
