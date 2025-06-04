using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Sorts
{
    public class PostLikeAdminSortType : SortInputType<PostLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<PostLike> descriptor)
        {
        descriptor.Name("PostLikeAdminSortInput");
        }
    }
}
