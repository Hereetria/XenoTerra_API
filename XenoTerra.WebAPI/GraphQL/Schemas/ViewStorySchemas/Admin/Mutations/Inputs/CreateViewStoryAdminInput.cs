using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations.Inputs
{
    public record CreateViewStoryAdminInput(
        string StoryId,
        string UserId
    );
}
