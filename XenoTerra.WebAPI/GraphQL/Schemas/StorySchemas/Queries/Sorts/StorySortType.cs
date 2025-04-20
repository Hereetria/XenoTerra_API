using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries.Sorts
{
    public class StorySortType : SortInputType<Story>
    {
        protected override void Configure(ISortInputTypeDescriptor<Story> descriptor)
        {
        }
    }
}
