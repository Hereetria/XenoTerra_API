using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs
{
    public record UpdateStorySelfInput(
        string StoryId,
        string? Path,
        bool? IsVideo,
        string? UserId
    );
}
