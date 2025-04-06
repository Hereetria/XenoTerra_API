using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class UserNestedFilterType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
            descriptor.Name("UserNestedFilterInput");
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
