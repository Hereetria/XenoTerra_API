using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class StoryHighlightNestedFilterType : FilterInputType<StoryHighlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryHighlight> descriptor)
        {
            descriptor.Name("StoryHighlightNestedFilterInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.HighlightId);
        }
    }
}
