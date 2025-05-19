using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Inputs
{
    public record UpdateViewStorySelfInput(
        string ViewStoryId,
        string? StoryId
    );
}
