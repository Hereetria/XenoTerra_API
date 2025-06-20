using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public
{
    public class PostLikePublicEdge
    {
        public ResultPostLikePublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
