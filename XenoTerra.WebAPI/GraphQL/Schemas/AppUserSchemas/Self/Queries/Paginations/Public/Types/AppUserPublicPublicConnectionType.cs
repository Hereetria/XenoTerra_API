using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public.Types
{
    public class AppUserPublicPublicConnectionType : ObjectType<AppUserPublicPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserPublicPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
