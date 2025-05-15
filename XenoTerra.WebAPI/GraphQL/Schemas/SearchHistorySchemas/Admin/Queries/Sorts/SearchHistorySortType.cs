using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Sorts
{
    public class SearchHistorySortType : SortInputType<SearchHistory>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistory> descriptor)
        {
        }
    }
}
