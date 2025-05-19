using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Filters
{
    public class RoleAdminFilterType : FilterInputType<Role>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Role> descriptor)
        {
        descriptor.Name("RoleAdminFilterInput");
        }
    }
}
