using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Own.Types
{
    public class NotificationOwnConnectionType : ObjectType<NotificationOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
