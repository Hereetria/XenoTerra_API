using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Sorts
{
    public class ReportPostAdminSortType : SortInputType<ReportPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportPost> descriptor)
        {
        descriptor.Name("ReportPostAdminSortInput");
        }
    }
}
