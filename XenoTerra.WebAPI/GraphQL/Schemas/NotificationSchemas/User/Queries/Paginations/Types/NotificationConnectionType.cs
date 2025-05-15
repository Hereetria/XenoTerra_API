using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations.Types
{
    public class NotificationConnectionType : ObjectType<NotificationConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
