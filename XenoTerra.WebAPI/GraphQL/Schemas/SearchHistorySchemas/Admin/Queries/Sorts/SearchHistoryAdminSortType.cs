using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Sorts
{
    public class SearchHistoryAdminSortType : SortInputType<SearchHistory>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistory> descriptor)
        {
        descriptor.Name("SearchHistoryAdminSortInput");
        }
    }
}
