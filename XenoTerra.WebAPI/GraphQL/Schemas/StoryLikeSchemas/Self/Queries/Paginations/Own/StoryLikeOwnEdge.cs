using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Paginations.Own
{
    public class StoryLikeOwnEdge
    {
        public ResultStoryLikeWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
