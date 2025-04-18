using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Queries.Paginations
{
    public class LikeEdge
    {
        public ResultLikeWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
