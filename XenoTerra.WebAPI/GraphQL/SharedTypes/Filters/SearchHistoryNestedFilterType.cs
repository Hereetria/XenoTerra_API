using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class SearchHistoryNestedFilterType : FilterInputType<SearchHistory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistory> descriptor)
        {
            descriptor.Name("SearchHistoryNestedFilterInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.SearchedAt);
        }
    }
}
