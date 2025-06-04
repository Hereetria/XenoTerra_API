using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Sorts
{
    public class AppRoleAdminSortType : SortInputType<AppRole>
    {
        protected override void Configure(ISortInputTypeDescriptor<AppRole> descriptor)
        {
        descriptor.Name("RoleAdminSortInput");
        }
    }
}
