using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class StoryEdge
    {
        public ResultStoryWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
