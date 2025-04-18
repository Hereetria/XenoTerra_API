using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries
{
    public class ReportCommentSortType : SortInputType<ReportComment>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportComment> descriptor)
        {
        }
    }
}
