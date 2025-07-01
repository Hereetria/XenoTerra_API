using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Sorts
{
    public class SearchHistoryOwnSortType : SortInputType<SearchHistory>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistory> descriptor)
        {
        descriptor.Name("SearchHistoryOwnSortInput");
        }
    }
}
