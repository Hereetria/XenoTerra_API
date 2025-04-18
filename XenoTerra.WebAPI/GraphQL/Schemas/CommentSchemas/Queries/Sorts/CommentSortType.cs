using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries
{
    public class CommentSortType : SortInputType<Comment>
    {
        protected override void Configure(ISortInputTypeDescriptor<Comment> descriptor)
        {
        }
    }
}
