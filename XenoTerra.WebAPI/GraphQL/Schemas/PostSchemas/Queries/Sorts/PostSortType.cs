using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Sorts
{
    public class PostSortType : SortInputType<Post>
    {
        protected override void Configure(ISortInputTypeDescriptor<Post> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.Caption);
            descriptor.Field(f => f.Path);
            descriptor.Field(f => f.IsVideo);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
