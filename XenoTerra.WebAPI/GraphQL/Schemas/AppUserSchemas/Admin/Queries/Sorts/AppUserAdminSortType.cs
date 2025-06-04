using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Sorts
{
    public class AppUserAdminSortType : SortInputType<AppUser>
    {
        protected override void Configure(ISortInputTypeDescriptor<AppUser> descriptor)
        {
        descriptor.Name("UserAdminSortInput");
        }
    }
}
