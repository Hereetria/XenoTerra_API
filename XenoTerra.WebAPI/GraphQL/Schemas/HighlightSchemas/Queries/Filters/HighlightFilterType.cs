using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries.Filters
{
    public class HighlightFilterType : FilterInputType<Highlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Highlight> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.HighlightId);
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.ProfilePicturePath);

            descriptor.Field(f => f.StoryHighlights)
                .Type<StoryHighlightNestedFilterType>();
        }
    }
}
