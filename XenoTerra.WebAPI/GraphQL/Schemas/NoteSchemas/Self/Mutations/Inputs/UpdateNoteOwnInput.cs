using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs
{
    public record UpdateNoteOwnInput(
        string NoteId,
        string? Text
    );
}
