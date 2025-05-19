using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Filters
{
    public class HighlightAdminFilterType : FilterInputType<Highlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Highlight> descriptor)
        {
        descriptor.Name("HighlightAdminFilterInput");
        }
    }
}
