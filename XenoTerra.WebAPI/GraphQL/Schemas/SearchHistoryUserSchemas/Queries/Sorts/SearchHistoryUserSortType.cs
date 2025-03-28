using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Sorters
{
    public class SearchHistoryUserSortType : SortInputType<SearchHistoryUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SearchHistoryId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.SearchHistory)
                .Type<SearchHistoryNestedSortType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
