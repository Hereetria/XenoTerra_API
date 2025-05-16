namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateHighlightAdminInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
