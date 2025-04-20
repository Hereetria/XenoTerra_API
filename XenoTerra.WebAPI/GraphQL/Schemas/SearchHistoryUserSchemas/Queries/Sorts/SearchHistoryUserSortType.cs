using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Sorts
{
    public class SearchHistoryUserSortType : SortInputType<SearchHistoryUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
        }
    }
}
