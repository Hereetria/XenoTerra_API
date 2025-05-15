using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs
{
    public record UpdatePostInput(
        string PostId,
        string? Caption,
        string? Path,
        bool? IsVideo,
        string? UserId
    );
}
