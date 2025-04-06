using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class ReportCommentNestedSortType : SortInputType<ReportComment>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportComment> descriptor)
        {
            descriptor.Name("ReportCommentNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReportCommentId);
            descriptor.Field(f => f.ReporterUserId);
            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Reason);
            descriptor.Field(f => f.ReportedAt);
        }
    }
}
