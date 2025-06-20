using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs
{
    public record CreateNoteOwnInput(
        string Text
    );
}
