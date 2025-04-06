using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class FollowNestedSortType : SortInputType<Follow>
    {
        protected override void Configure(ISortInputTypeDescriptor<Follow> descriptor)
        {
            descriptor.Name("FollowNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.FollowId);
            descriptor.Field(f => f.FollowerId);
            descriptor.Field(f => f.FollowingId);
            descriptor.Field(f => f.FollowedAt);
        }
    }
}
