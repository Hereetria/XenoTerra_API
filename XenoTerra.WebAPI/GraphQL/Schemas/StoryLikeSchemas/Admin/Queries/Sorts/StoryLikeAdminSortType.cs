using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Sorts
{
    public class StoryLikeAdminSortType : SortInputType<StoryLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<StoryLike> descriptor)
        {
        descriptor.Name("StoryLikeAdminSortInput");
        }
    }
}
