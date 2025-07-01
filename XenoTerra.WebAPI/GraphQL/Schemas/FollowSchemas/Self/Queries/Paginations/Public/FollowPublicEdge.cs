using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Public
{
    public class FollowPublicEdge
    {
        public ResultFollowWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
