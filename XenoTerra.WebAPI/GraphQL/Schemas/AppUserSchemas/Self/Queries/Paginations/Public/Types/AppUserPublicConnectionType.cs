using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public.Types
{
    public class AppUserPublicConnectionType : ObjectType<AppUserPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
