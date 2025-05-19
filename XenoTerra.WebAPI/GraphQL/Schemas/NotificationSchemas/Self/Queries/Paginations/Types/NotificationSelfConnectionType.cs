using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Types
{
    public class NotificationSelfConnectionType : ObjectType<NotificationSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
