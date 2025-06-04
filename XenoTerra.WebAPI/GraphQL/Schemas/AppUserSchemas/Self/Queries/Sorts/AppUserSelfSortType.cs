using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Sorts
{
    public class AppUserSelfSortType : SortInputType<AppUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<AppUser> descriptor)
        {
            descriptor.Name("UserSelfSortInput");
        }
    }
}
