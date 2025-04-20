using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Sorts
{
    public class BlockUserSortType : SortInputType<BlockUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<BlockUser> descriptor)
        {
        }
    }
}
