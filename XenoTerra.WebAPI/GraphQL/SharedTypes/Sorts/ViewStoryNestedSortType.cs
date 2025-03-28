using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class ViewStoryNestedSortType : SortInputType<ViewStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ViewStory> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ViewStoryId);
            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.ViewedAt);
        }
    }
}
