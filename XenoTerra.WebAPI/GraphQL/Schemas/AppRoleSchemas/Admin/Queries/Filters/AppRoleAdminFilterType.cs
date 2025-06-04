using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Filters
{
    public class AppRoleAdminFilterType : FilterInputType<AppRole>
    {
        protected override void Configure(IFilterInputTypeDescriptor<AppRole> descriptor)
        {
        descriptor.Name("RoleAdminFilterInput");
        }
    }
}
