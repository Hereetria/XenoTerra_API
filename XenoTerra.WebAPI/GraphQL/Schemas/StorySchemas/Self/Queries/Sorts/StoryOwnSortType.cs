using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Sorts
{
    public class StoryOwnSortType : SortInputType<Story>
    {
        protected override void Configure(ISortInputTypeDescriptor<Story> descriptor)
        {
        descriptor.Name("StoryOwnSortInput");
        }
    }
}
