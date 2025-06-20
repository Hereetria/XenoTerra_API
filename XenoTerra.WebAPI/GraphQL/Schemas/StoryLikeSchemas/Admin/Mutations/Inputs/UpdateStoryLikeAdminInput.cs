using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Inputs
{
    public record UpdateStoryLikeAdminInput(
        string StoryLikeId,
        string? StoryId,
        string? UserId
    );
}
