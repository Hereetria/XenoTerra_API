using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs
{
    public record CreateNoteInput(
        string Text,
        string UserId
    );
}
