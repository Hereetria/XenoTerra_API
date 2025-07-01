using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations
{
    public class HighlightAdminEdge
    {
        public ResultHighlightWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
