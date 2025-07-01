using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Sorts
{
    public class FollowPublicSortType : SortInputType<Follow>
    {
        protected override void Configure(ISortInputTypeDescriptor<Follow> descriptor)
        {
        descriptor.Name("FollowPublicSortInput");
        }
    }
}
