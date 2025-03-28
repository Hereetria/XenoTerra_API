using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries.Filters
{
    public class StoryFilterType : FilterInputType<Story>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Story> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.Path);
            descriptor.Field(f => f.IsVideo);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.ViewStories)
                .Type<ViewStoryNestedFilterType>();

            descriptor.Field(f => f.StoryHighlights)
                .Type<StoryHighlightNestedFilterType>();
        }
    }
}
