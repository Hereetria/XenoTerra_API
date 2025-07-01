using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations.Own
{
    public class SearchHistoryOwnEdge
    {
        public ResultSearchHistoryWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
