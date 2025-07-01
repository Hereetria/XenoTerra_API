using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Own
{
    public class NoteOwnEdge
    {
        public ResultNoteWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
