using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Sorts
{
    public class ReportCommentOwnSortType : SortInputType<ReportComment>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportComment> descriptor)
        {
        descriptor.Name("ReportCommentOwnSortInput");
        }
    }
}
