namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs
{
    public record UpdateHighlightOwnInput(
        string HighlightId,
        string? Name,
        string? ProfilePicturePath
    );
}
