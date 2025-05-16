using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs
{
    public record CreateSavedPostSelfInput(
        string UserId,
        string PostId
    );
}
