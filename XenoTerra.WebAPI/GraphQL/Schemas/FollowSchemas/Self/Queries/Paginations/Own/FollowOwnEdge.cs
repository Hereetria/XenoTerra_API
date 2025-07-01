using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Own
{
    public class FollowOwnEdge
    {
        public ResultFollowWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
