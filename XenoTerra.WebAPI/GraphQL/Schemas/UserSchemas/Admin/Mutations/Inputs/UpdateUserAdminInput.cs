using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Inputs
{
    public record UpdateUserAdminInput(
        string Id,
        string? FullName,
        string? Bio,
        string? ProfilePicture,
        string? Website,
        [property: DateField] string? BirthDate,
        bool? IsVerified,
        int? FollowersCount,
        int? FollowingCount,
        [property: DateField] string? LastActive
    );
}
