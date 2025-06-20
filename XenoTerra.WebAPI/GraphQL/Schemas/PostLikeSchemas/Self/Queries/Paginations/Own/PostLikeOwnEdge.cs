using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own
{
    public class PostLikeOwnEdge
    {
        public ResultPostLikeWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
