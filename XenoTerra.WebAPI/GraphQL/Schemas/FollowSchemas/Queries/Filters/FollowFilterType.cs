using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.FollowQueries.Filters
{
    public class FollowFilterType : FilterInputType<Follow>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Follow> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.FollowId);
            descriptor.Field(f => f.FollowerId);
            descriptor.Field(f => f.FollowingId);
            descriptor.Field(f => f.FollowedAt);

            descriptor.Field(f => f.Follower)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Following)
                .Type<UserNestedFilterType>();
        }
    }
}
