using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries.Filters
{
    public class CommentFilterType : FilterInputType<Comment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Comment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CommentedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedFilterType>();

            descriptor.Field(f => f.ReportComments)
                .Type<ReportCommentNestedFilterType>();
        }
    }
}
