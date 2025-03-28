using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class HighlightEdge
    {
        public ResultHighlightWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
