using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries
{
    public class LikeSortType : SortInputType<Like>
    {
        protected override void Configure(ISortInputTypeDescriptor<Like> descriptor)
        {
        }
    }
}
