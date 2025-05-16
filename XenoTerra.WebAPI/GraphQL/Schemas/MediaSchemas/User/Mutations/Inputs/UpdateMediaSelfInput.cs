using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs
{
    public record UpdateMediaSelfInput(
        string MediaId,
        string? PhotoUrl,
        string? UserId
    );
}
