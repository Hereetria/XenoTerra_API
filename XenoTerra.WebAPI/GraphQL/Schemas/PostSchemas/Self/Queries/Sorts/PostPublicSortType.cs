using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Sorts
{
    public class PostPublicSortType : SortInputType<Post>
    {
        protected override void Configure(ISortInputTypeDescriptor<Post> descriptor)
        {
        descriptor.Name("PostPublicSortInput");
        }
    }
}
