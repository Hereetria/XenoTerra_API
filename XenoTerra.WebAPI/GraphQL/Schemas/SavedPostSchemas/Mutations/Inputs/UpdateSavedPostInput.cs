using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Inputs
{
    public record UpdateSavedPostInput(
        string SavedPostId,
        string? UserId,
        string? PostId,
        [property: DateField] string? SavedAt
    );
}
