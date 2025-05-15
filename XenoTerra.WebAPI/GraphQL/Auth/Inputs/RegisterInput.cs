using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Auth.Inputs
{
    public record RegisterInput(
        string UserName,
        string Password,
        string ConfirmPassword,
        string Email,
        string FullName,
        [property: DateField] string BirthDate
    );
}
