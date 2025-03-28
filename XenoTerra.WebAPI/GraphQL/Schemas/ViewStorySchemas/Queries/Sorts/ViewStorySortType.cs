using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries.Sorts
{
    public class ViewStorySortType : SortInputType<ViewStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ViewStory> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ViewStoryId);
            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.ViewedAt);

            descriptor.Field(f => f.Story)
                .Type<StoryNestedSortType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
