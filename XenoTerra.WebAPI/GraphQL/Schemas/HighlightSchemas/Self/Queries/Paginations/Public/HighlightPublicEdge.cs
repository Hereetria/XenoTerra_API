using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public
{
    public class HighlightPublicEdge
    {
        public ResultHighlightPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
