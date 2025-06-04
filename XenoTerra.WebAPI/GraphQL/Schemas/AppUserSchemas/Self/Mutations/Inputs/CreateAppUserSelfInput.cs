using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Inputs
{
    public record CreateUserSelfInput(
        string UserName,
        string Password,
        string ConfirmPassword,
        string Email,
        string FullName,
        [property: DateField] string BirthDate
    );
}
