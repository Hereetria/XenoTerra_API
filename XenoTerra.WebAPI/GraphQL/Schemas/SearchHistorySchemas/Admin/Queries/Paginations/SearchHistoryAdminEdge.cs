using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations
{
    public class SearchHistoryAdminEdge
    {
        public ResultSearchHistoryWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
