using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own
{
    public class StoryOwnEdge
    {
        public ResultStoryWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
