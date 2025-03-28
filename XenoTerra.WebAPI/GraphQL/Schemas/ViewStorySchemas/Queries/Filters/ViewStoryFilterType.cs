using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries.Filters
{
    public class ViewStoryFilterType : FilterInputType<ViewStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ViewStory> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ViewStoryId);
            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.ViewedAt);

            descriptor.Field(f => f.Story)
                .Type<StoryNestedFilterType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
