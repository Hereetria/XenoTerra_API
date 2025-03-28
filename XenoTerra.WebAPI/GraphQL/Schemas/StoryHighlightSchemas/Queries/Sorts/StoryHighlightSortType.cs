using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Sorts
{
    public class StoryHighlightSortType : SortInputType<StoryHighlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<StoryHighlight> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.HighlightId);

            descriptor.Field(f => f.Story)
                .Type<StoryNestedSortType>();

            descriptor.Field(f => f.Highlight)
                .Type<HighlightNestedSortType>();
        }
    }
}
