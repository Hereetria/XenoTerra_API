using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries.Filters
{
    public class SearchHistoryFilterType : FilterInputType<SearchHistory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistory> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.SearchedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.SearchedUsers)
                .Type<SearchHistoryUserNestedFilterType>();
        }
    }
}
