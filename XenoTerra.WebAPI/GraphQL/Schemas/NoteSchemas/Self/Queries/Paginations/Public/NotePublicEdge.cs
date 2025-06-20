using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Public
{
    public class NotePublicEdge
    {
        public ResultNotePublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
