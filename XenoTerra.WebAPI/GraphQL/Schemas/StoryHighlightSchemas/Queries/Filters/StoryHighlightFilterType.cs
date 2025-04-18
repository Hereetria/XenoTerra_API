using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Filters
{
    public class StoryHighlightFilterType : FilterInputType<StoryHighlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryHighlight> descriptor)
        {
        }
    }
}
