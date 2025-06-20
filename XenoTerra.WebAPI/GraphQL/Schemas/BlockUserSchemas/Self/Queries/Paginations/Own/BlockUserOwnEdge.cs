using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Own
{
    public class BlockUserOwnEdge
    {
        public ResultBlockUserWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
