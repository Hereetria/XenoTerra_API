using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations
{
    public class BlockUserAdminEdge
    {
        public ResultBlockUserWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
