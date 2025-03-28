using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.FollowQueries.Sorts
{
    public class FollowSortType : SortInputType<Follow>
    {
        protected override void Configure(ISortInputTypeDescriptor<Follow> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.FollowId);
            descriptor.Field(f => f.FollowerId);
            descriptor.Field(f => f.FollowingId);
            descriptor.Field(f => f.FollowedAt);

            descriptor.Field(f => f.Follower)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Following)
                .Type<UserNestedSortType>();
        }
    }
}
