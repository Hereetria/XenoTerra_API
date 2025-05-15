using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations
{
    public class MediaEdge
    {
        public ResultMediaWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
