using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class ViewStoryEdge
    {
        public ResultViewStoryWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
