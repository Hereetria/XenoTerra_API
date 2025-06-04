using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations.Types
{
    public class AppUserAdminConnectionType : ObjectType<AppUserAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
