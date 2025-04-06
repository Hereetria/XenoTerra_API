using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class CommentNestedSortType : SortInputType<Comment>
    {
        protected override void Configure(ISortInputTypeDescriptor<Comment> descriptor)
        {
            descriptor.Name("CommentNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CommentedAt);
        }
    }
}
