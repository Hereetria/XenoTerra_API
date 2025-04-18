using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Filters
{
    public class SearchHistoryUserFilterType : FilterInputType<SearchHistoryUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
        }
    }
}
