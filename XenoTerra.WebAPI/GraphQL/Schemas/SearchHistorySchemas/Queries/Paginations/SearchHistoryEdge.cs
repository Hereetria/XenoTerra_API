using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Queries.Paginations
{
    public class SearchHistoryEdge
    {
        public ResultSearchHistoryWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
