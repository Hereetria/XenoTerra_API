using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs
{
    public record CreatePostSelfInput(
        string Caption,
        string Path,
        bool IsVideo
    );
}
