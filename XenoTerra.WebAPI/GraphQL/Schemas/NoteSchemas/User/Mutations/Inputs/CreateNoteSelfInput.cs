using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs
{
    public record CreateNoteSelfInput(
        string Text,
        string UserId
    );
}
