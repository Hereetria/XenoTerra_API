using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries.Filters
{
    public class ReportCommentFilterType : FilterInputType<ReportComment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ReportComment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReportCommentId);
            descriptor.Field(f => f.ReporterUserId);
            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Reason);
            descriptor.Field(f => f.ReportedAt);

            descriptor.Field(f => f.ReporterUser)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Comment)
                .Type<CommentNestedFilterType>();
        }
    }
}
