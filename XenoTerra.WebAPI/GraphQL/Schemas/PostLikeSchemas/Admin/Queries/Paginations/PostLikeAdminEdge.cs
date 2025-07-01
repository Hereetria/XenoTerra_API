using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations
{
    public class PostLikeAdminEdge
    {
        public ResultPostLikeWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
