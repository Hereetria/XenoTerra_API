using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class UserPostTagNestedSortType : SortInputType<UserPostTag>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
        }
    }
}
