using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Sorts
{
    public class CommentLikeSelfSortType : SortInputType<CommentLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<CommentLike> descriptor)
        {
        descriptor.Name("CommentLikeSelfSortInput");
        }
    }
}
