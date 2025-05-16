using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Inputs
{
    public record CreateViewStoryAdminInput(
        string StoryId,
        string UserId
    );
}
