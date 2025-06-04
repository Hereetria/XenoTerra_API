namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Types
{
    public class AppUserPrivateSelfConnectionType : ObjectType<AppUserPrivateSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppUserPrivateSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
