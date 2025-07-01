using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Public
{
    public class NotePublicEdge
    {
        public ResultNoteWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
