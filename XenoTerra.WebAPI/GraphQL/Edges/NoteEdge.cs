using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class NoteEdge
    {
        public ResultNoteWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
