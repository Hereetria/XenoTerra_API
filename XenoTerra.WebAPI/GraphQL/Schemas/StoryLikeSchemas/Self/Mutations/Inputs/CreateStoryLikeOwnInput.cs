using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Inputs
{
    public record CreateStoryLikeOwnInput(
        string StoryId
    );
}
