using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Sorts
{
    public class UserSortType : SortInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
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
