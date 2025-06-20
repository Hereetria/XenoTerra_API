using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Sorts
{
    public class PostLikeSortType : SortInputType<PostLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<PostLike> descriptor)
        {
        descriptor.Name("PostLikeSortInput");
        }
    }
}
