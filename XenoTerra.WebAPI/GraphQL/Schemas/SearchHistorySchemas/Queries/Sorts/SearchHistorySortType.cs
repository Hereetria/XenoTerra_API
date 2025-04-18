using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries.Sorts
{
    public class SearchHistorySortType : SortInputType<SearchHistory>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistory> descriptor)
        {
        }
    }
}
