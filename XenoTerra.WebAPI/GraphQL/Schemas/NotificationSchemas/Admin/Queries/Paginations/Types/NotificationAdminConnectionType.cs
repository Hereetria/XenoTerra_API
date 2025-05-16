using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations.Types
{
    public class NotificationAdminConnectionType : ObjectType<NotificationAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
