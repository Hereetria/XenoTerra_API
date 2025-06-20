using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Filters
{
    public class ReportPostFilterType : FilterInputType<ReportPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportPost> descriptor)
        {
        descriptor.Name("ReportPostFilterInput");
        }
    }
}
