using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Filters
{
    public class ReportStoryOwnFilterType : FilterInputType<ReportStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportStory> descriptor)
        {
        descriptor.Name("ReportStoryOwnFilterInput");
        }
    }
}
