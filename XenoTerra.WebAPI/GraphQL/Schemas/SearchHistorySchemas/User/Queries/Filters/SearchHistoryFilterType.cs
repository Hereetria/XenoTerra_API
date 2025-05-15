using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Filters
{
    public class SearchHistoryFilterType : FilterInputType<SearchHistory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistory> descriptor)
        {
        }
    }
}
