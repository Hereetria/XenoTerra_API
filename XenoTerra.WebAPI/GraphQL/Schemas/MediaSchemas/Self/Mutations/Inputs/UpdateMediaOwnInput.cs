using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs
{
    public record UpdateMediaOwnInput(
        string MediaId,
        string? PhotoUrl
    );
}
