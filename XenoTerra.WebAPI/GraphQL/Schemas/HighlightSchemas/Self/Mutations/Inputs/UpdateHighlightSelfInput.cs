namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs
{
    public record UpdateHighlightSelfInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
