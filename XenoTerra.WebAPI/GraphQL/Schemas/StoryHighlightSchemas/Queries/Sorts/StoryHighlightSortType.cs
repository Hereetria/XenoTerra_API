using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Sorts
{
    public class StoryHighlightSortType : SortInputType<StoryHighlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<StoryHighlight> descriptor)
        {
        }
    }
}
