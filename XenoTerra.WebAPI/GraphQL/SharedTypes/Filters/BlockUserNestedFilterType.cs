using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class BlockUserNestedFilterType : FilterInputType<BlockUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<BlockUser> descriptor)
        {
            descriptor.Name("BlockUserNestedFilterInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.BlockUserId);
            descriptor.Field(f => f.BlockingUserId);
            descriptor.Field(f => f.BlockedUserId);
            descriptor.Field(f => f.BlockedAt);
        }
    }
}
