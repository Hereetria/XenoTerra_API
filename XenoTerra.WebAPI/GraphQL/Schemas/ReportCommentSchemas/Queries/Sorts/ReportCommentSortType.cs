using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries
{
    public class ReportCommentSortType : SortInputType<ReportComment>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportComment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReportCommentId);
            descriptor.Field(f => f.ReporterUserId);
            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Reason);
            descriptor.Field(f => f.ReportedAt);

            descriptor.Field(f => f.ReporterUser)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Comment)
                .Type<CommentNestedSortType>();
        }
    }
}
