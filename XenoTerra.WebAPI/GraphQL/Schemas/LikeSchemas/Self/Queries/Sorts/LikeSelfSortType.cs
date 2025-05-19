using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Sorts
{
    public class LikeSelfSortType : SortInputType<Like>
    {
        protected override void Configure(ISortInputTypeDescriptor<Like> descriptor)
        {
        descriptor.Name("LikeSelfSortInput");
        }
    }
}
