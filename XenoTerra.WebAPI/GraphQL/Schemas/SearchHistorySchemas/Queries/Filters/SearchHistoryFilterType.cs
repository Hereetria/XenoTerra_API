using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries.Filters
{
    public class SearchHistoryFilterType : FilterInputType<SearchHistory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistory> descriptor)
        {
        }
    }
}
