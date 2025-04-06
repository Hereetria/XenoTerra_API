using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class SearchHistoryUserNestedSortType : SortInputType<SearchHistoryUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
            descriptor.Name("SearchHistoryUserNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);
        }
    }
}
