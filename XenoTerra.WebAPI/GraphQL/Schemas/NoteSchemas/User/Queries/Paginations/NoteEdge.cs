using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations
{
    public class NoteEdge
    {
        public ResultNoteWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
