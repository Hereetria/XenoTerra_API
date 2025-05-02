using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Inputs
{
    public record CreateNoteInput(
        string Text,
        string UserId
    );
}
