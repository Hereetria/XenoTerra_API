using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Inputs
{
    public record CreateStoryInput(
        string Path,
        bool IsVideo,
        string UserId,
        [property: DateField] string CreatedAt
    );
}
