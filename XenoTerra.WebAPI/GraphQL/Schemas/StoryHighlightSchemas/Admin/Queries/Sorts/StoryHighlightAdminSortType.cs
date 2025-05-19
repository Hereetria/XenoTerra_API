using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Sorts
{
    public class StoryHighlightAdminSortType : SortInputType<StoryHighlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<StoryHighlight> descriptor)
        {
        descriptor.Name("StoryHighlightAdminSortInput");
        }
    }
}
