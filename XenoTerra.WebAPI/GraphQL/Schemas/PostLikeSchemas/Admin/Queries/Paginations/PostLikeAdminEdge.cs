using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations
{
    public class PostLikeAdminEdge
    {
        public ResultPostLikeWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
