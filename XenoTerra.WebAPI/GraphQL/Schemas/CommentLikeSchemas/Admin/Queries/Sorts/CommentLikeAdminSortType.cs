using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Sorts
{
    public class CommentLikeAdminSortType : SortInputType<CommentLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<CommentLike> descriptor)
        {
        descriptor.Name("CommentLikeAdminSortInput");
        }
    }
}
