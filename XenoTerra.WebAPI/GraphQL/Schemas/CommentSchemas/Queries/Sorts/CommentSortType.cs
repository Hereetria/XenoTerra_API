using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries
{
    public class CommentSortType : SortInputType<Comment>
    {
        protected override void Configure(ISortInputTypeDescriptor<Comment> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.CommentId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CommentedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedSortType>();
        }
    }
}
