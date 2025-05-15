using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs
{
    public record UpdateNoteInput(
        string NoteId,
        string? Text,
        string? UserId
    );
}
