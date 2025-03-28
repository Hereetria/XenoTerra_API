using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class FollowNestedFilterType : FilterInputType<Follow>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Follow> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.FollowId);
            descriptor.Field(f => f.FollowerId);
            descriptor.Field(f => f.FollowingId);
            descriptor.Field(f => f.FollowedAt);
        }
    }
}
