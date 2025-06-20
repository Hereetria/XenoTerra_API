using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Public
{
    public class FollowPublicEdge
    {
        public ResultFollowPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
