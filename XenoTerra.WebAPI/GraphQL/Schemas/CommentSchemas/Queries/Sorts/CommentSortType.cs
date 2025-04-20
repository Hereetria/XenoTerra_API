using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Queries.Sorts
{
    public class CommentSortType : SortInputType<Comment>
    {
        protected override void Configure(ISortInputTypeDescriptor<Comment> descriptor)
        {
        }
    }
}
