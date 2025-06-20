using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own.Types
{
    public class AppUserOwnOwnConnectionType : ObjectType<AppUserOwnOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserOwnOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
