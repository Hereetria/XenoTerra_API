using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Sorts
{
    public class RoleAdminSortType : SortAdminInputType<Role>
    {
        protected override void Configure(ISortInputTypeDescriptor<Role> descriptor)
        {
        }
    }
}
