using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Filters
{
    public class SearchHistoryOwnFilterType : FilterInputType<SearchHistory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistory> descriptor)
        {
        descriptor.Name("SearchHistoryOwnFilterInput");
        }
    }
}
