using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Sorts
{
    public class SearchHistoryUserSelfSortType : SortSelfInputType<SearchHistoryUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
        }
    }
}
