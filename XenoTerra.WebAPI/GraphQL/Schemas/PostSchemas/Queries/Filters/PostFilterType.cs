using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Filters
{
    public class PostFilterType : FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.Caption);
            descriptor.Field(f => f.Path);
            descriptor.Field(f => f.IsVideo);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Likes)
                .Type<LikeNestedFilterType>();

            descriptor.Field(f => f.Comments)
                .Type<CommentNestedFilterType>();

            descriptor.Field(f => f.SavedPosts)
                .Type<SavedPostNestedFilterType>();

            descriptor.Field(f => f.TaggedUsers)
                .Type<UserPostTagNestedFilterType>();
        }
    }
}
