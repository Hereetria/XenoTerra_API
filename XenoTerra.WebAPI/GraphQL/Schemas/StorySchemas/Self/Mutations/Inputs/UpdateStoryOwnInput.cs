using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs
{
    public record UpdateStoryOwnInput(
        string StoryId,
        string? Path,
        bool? IsVideo
    );
}
