using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class BlockUserNestedSortType : SortInputType<BlockUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<BlockUser> descriptor)
        {
            descriptor.Name("BlockUserNestedSortInput");

            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.BlockUserId);
            descriptor.Field(f => f.BlockingUserId);
            descriptor.Field(f => f.BlockedUserId);
            descriptor.Field(f => f.BlockedAt);
        }
    }
}
