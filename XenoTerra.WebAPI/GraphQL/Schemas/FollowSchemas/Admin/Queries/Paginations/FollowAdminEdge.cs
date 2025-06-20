using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations
{
    public class FollowAdminEdge
    {
        public ResultFollowWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
