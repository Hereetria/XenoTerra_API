using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Filters
{
    public class AppUserAdminFilterType : FilterInputType<AppUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<AppUser> descriptor)
        {
        descriptor.Name("UserAdminFilterInput");
        }
    }
}
