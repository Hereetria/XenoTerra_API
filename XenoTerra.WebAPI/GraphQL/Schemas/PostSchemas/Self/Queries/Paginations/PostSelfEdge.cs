using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations
{
    public class PostSelfEdge
    {
        public ResultPostWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
