using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own.Types
{
    public class AppUserOwnConnectionType : ObjectType<AppUserOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
