using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Types
{
    public class AppUserPublicSelfConnectionType : ObjectType<AppUserPublicSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserPublicSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
