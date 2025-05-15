using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Sorts
{
    public class RoleSortType : SortInputType<Role>
    {
        protected override void Configure(ISortInputTypeDescriptor<Role> descriptor)
        {
        }
    }
}
