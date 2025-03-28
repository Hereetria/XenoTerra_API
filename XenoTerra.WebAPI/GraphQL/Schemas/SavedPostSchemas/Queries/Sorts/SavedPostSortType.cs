using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Sorts
{
    public class SavedPostSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SavedPostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.SavedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedSortType>();
        }
    }
}
