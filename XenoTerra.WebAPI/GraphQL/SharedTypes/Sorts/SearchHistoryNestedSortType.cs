using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class SearchHistoryNestedSortType : SortInputType<SearchHistory>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistory> descriptor)
        {
            descriptor.Name("SearchHistoryNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.SearchedAt);
        }
    }
}
