using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Public.Types
{
    public class NotificationPublicConnectionType : ObjectType<NotificationPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
