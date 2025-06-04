using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Filters
{
    public class ReportPostAdminFilterType : FilterInputType<ReportPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportPost> descriptor)
        {
        descriptor.Name("ReportPostAdminFilterInput");
        }
    }
}
