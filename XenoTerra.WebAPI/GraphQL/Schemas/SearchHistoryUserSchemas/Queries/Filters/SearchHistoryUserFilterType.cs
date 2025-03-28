using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Filters
{
    public class SearchHistoryUserFilterType : FilterInputType<SearchHistoryUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.SearchHistory)
                .Type<SearchHistoryNestedFilterType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
