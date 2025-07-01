using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Filters
{
    public class AppUserOwnFilterType : FilterInputType<AppUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<AppUser> descriptor)
        {
            descriptor.Name("UserOwnFilterInput");
        }
    }
}
