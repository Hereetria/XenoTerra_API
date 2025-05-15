using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Sorts
{
    public class PostSortType : SortInputType<Post>
    {
        protected override void Configure(ISortInputTypeDescriptor<Post> descriptor)
        {
        }
    }
}
