using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations.Inputs
{
    public record UpdateViewStoryAdminInput(
        string ViewStoryId,
        string? StoryId,
        string? UserId
    );
}
