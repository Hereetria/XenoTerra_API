using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Sorts
{
    public class ReportStoryAdminSortType : SortInputType<ReportStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportStory> descriptor)
        {
        descriptor.Name("ReportStoryAdminSortInput");
        }
    }
}
