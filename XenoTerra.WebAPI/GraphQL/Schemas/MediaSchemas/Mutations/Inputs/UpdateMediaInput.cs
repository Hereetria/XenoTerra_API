using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Inputs
{
    public record UpdateMediaInput(
        string MediaId,
        string? PhotoUrl,
        string? UserId,
        [property: DateField] string? UploadedAt
    );
}
