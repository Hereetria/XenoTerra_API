namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateHighlightInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
