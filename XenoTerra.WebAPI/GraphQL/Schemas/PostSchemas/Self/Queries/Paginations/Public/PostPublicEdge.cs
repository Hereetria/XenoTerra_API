using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public
{
    public class PostPublicEdge
    {
        public ResultPostPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
