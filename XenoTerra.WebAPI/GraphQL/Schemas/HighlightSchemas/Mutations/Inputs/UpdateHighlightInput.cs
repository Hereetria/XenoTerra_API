namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Inputs
{
    public record UpdateHighlightInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
