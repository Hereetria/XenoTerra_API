using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Filters
{
    public class ReportStoryFilterType : FilterInputType<ReportStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportStory> descriptor)
        {
        descriptor.Name("ReportStoryFilterInput");
        }
    }
}
