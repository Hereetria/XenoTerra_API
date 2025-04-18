using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Sorters
{
    public class SearchHistoryUserSortType : SortInputType<SearchHistoryUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
        }
    }
}
