using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class SearchHistoryEdge
    {
        public ResultSearchHistoryWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
