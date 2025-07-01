using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Sorts
{
    public class StoryLikeOwnSortType : SortInputType<StoryLike>
    {
        protected override void Configure(ISortInputTypeDescriptor<StoryLike> descriptor)
        {
        descriptor.Name("StoryLikeOwnSortInput");
        }
    }
}
