using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries.Sorts
{
    public class StorySortType : SortInputType<Story>
    {
        protected override void Configure(ISortInputTypeDescriptor<Story> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.StoryId);
            descriptor.Field(f => f.Path);
            descriptor.Field(f => f.IsVideo);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
