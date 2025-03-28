using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class ReportCommentNestedFilterType : FilterInputType<ReportComment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportComment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReportCommentId);
            descriptor.Field(f => f.ReporterUserId);
            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Reason);
            descriptor.Field(f => f.ReportedAt);
        }
    }
}
