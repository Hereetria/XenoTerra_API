using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs
{
    public record CreateSavedPostInput(
        string UserId,
        string PostId
    );
}
