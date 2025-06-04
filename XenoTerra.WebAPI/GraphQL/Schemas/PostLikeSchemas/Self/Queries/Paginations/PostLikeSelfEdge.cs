using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations
{
    public class PostLikeSelfEdge
    {
        public ResultPostLikeWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
