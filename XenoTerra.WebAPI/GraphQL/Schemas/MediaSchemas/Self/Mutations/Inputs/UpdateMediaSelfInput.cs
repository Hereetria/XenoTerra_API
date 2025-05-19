using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs
{
    public record UpdateMediaSelfInput(
        string MediaId,
        string? PhotoUrl
    );
}
