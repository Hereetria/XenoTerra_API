using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Filters
{
    public class ReportStoryAdminFilterType : FilterInputType<ReportStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportStory> descriptor)
        {
        descriptor.Name("ReportStoryAdminFilterInput");
        }
    }
}
