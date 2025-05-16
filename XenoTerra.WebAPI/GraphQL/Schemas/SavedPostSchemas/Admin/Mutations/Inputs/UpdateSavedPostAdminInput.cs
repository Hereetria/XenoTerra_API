using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs
{
    public record UpdateSavedPostAdminInput(
        string SavedPostId,
        string? UserId,
        string? PostId
    );
}
