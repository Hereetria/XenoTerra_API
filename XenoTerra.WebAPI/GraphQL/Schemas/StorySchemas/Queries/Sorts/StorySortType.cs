using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries.Sorts
{
    public class StorySortType : SortInputType<Story>
    {
        protected override void Configure(ISortInputTypeDescriptor<Story> descriptor)
        {
        }
    }
}
