using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations
{
    public class StoryLikeAdminEdge
    {
        public ResultStoryLikeWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
