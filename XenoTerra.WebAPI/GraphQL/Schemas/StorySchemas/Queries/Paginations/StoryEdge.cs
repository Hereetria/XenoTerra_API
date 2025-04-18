using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries.Paginations
{
    public class StoryEdge
    {
        public ResultStoryWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
