namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs
{
    public record CreateHighlightAdminInput(
        string Name,
        string ProfilePicturePath,
        string UserId
    );
}
