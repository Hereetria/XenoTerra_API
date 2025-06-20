using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations
{
    public class NoteAdminEdge
    {
        public ResultNoteWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
