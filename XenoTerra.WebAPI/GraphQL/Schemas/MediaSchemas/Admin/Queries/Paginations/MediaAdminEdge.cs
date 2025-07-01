using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations
{
    public class MediaAdminEdge
    {
        public ResultMediaWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
