using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs
{
    public record UpdatePostSelfInput(
        string PostId,
        string? Caption,
        string? Path,
        bool? IsVideo
    );
}
