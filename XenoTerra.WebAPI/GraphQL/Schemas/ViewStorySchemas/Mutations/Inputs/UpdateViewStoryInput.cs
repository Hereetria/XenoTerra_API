using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Inputs
{
    public record UpdateViewStoryInput(
        string ViewStoryId,
        string? StoryId,
        string? UserId,
        [property: DateField] string? ViewedAt
    );
}
