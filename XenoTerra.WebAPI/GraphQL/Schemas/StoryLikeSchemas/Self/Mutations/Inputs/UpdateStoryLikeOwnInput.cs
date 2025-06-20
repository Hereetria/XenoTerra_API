using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Inputs
{
    public record UpdateStoryLikeOwnInput(
        string StoryLikeId,
        string? StoryId
    );
}
