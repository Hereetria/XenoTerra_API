using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Inputs
{
    public record CreateMediaInput(
        string PhotoUrl,
        string UserId
    );
}
