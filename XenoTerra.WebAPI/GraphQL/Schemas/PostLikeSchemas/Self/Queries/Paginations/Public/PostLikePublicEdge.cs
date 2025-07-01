using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public
{
    public class PostLikePublicEdge
    {
        public ResultPostLikeWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
