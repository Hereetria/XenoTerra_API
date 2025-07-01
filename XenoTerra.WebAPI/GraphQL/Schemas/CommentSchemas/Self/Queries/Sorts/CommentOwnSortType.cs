using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Sorts
{
    public class CommentOwnSortType : SortInputType<Comment>
    {
        protected override void Configure(ISortInputTypeDescriptor<Comment> descriptor)
        {
        descriptor.Name("CommentOwnSortInput");
        }
    }
}
