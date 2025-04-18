using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Sorts
{
    public class PostSortType : SortInputType<Post>
    {
        protected override void Configure(ISortInputTypeDescriptor<Post> descriptor)
        {
        }
    }
}
