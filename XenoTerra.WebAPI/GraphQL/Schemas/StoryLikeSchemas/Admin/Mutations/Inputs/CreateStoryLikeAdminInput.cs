using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Inputs
{
    public record CreateStoryLikeAdminInput(
        string StoryId,
        string UserId
    );
}
