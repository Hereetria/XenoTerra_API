using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Filters
{
    public class StoryHighlightFilterType : FilterInputType<StoryHighlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryHighlight> descriptor)
        {
        }
    }
}
