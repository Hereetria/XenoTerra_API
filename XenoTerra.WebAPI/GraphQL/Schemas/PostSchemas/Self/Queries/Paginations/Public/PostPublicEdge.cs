using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public
{
    public class PostPublicEdge
    {
        public ResultPostWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
