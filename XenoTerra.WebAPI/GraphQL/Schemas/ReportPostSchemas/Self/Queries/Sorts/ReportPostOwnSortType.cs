using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Sorts
{
    public class ReportPostOwnSortType : SortInputType<ReportPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportPost> descriptor)
        {
        descriptor.Name("ReportPostOwnSortInput");
        }
    }
}
