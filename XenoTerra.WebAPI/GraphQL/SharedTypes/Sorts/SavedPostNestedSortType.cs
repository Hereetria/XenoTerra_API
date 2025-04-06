using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class SavedPostNestedSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
            descriptor.Name("SavedPostNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SavedPostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.SavedAt);
        }
    }
}
