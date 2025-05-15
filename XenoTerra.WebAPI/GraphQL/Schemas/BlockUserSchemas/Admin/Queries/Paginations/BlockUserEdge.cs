using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations
{
    public class BlockUserEdge
    {
        public ResultBlockUserWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
