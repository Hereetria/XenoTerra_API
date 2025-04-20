using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Inputs
{
    public record UpdateNoteInput(
        string NoteId,
        string? Text,
        string? UserId,
        [property: DateField] string? CreatedAt
    );
}
