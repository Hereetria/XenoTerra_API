using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Inputs
{
    public record UpdateSavedPostSelfInput(
        string SavedPostId,
        string? PostId
    );
}
