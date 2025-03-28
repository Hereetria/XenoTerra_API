using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleQueries.Sorts
{
    public class RoleSortType : SortInputType<Role>
    {
        protected override void Configure(ISortInputTypeDescriptor<Role> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.Name);
        }
    }
}
