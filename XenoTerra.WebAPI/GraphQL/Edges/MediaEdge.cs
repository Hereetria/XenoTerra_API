using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class MediaEdge
    {
        public ResultMediaWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
