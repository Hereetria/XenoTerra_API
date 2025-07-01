using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations
{
    public class BlockUserAdminEdge
    {
        public ResultBlockUserWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
