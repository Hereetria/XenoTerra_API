using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class UserNestedSortType : SortInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
            descriptor.Name("UserNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.FullName);
            descriptor.Field(f => f.Bio);
            descriptor.Field(f => f.ProfilePicture);
            descriptor.Field(f => f.Website);
            descriptor.Field(f => f.BirthDate);
            descriptor.Field(f => f.FollowersCount);
            descriptor.Field(f => f.FollowingCount);
            descriptor.Field(f => f.IsVerified);
            descriptor.Field(f => f.LastActive);
        }
    }
}
