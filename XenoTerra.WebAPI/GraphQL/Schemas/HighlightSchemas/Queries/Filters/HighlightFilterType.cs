using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries.Filters
{
    public class HighlightFilterType : FilterInputType<Highlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Highlight> descriptor)
        {
        }
    }
}
