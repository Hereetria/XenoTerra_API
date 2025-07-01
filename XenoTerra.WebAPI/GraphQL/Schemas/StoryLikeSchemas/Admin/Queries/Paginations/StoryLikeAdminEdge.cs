using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations
{
    public class StoryLikeAdminEdge
    {
        public ResultStoryLikeWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
