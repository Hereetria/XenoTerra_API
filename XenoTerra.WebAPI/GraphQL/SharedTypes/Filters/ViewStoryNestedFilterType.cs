using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class ViewStoryNestedFilterType : FilterInputType<ViewStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ViewStory> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ViewStoryId);
            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.ViewedAt);
        }
    }
}
