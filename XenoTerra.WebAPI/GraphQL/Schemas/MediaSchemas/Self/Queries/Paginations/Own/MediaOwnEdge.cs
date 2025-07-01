using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations.Own
{
    public class MediaOwnEdge
    {
        public ResultMediaWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
