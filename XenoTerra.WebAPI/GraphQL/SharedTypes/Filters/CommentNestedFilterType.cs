using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class CommentNestedFilterType : FilterInputType<Comment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Comment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CommentedAt);
        }
    }
}
