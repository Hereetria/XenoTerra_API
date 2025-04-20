using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Queries.Sorts
{
    public class LikeSortType : SortInputType<Like>
    {
        protected override void Configure(ISortInputTypeDescriptor<Like> descriptor)
        {
        }
    }
}
