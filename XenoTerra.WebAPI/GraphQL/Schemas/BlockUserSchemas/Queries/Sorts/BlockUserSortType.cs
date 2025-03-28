using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Sorts
{
    public class BlockUserSortType : SortInputType<BlockUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<BlockUser> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.BlockUserId);
            descriptor.Field(f => f.BlockingUserId);
            descriptor.Field(f => f.BlockedUserId);
            descriptor.Field(f => f.BlockedAt);

            descriptor.Field(f => f.BlockingUser)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.BlockedUser)
                .Type<UserNestedSortType>();
        }
    }
}
