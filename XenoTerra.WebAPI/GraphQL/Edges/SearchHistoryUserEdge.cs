using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class SearchHistoryUserEdge
    {
        public ResultSearchHistoryUserWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
