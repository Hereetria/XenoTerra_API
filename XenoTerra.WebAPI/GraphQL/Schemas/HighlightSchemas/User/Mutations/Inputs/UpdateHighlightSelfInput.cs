namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateHighlightSelfInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
