using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries
{
    public class LikeSortType : SortInputType<Like>
    {
        protected override void Configure(ISortInputTypeDescriptor<Like> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.LikeId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LikedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedSortType>();
        }
    }
}
