using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Filters
{
    public class StoryHighlightFilterType : FilterInputType<StoryHighlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryHighlight> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.HighlightId);

            descriptor.Field(f => f.Story)
                .Type<StoryNestedFilterType>();

            descriptor.Field(f => f.Highlight)
                .Type<HighlightNestedFilterType>();
        }
    }
}
