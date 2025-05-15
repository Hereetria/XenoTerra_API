namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs
{
    public record CreateHighlightInput(
        string Name,
        string ProfilePicturePath
    );
}
