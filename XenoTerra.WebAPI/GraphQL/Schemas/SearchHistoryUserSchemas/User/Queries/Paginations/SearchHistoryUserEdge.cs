using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations
{
    public class SearchHistoryUserEdge
    {
        public ResultSearchHistoryUserWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
