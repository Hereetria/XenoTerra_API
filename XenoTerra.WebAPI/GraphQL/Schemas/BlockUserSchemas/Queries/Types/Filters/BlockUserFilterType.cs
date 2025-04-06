using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Types.Filters
{
    public class BlockUserFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.BlockUserId);
            descriptor.Field(f => f.BlockingUserId);
            descriptor.Field(f => f.BlockedUserId);
            descriptor.Field(f => f.BlockedAt);

            descriptor.Field(f => f.BlockingUser)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.BlockedUser)
                .Type<UserNestedFilterType>();
        }
    }
}
