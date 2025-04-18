namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Paginations.Types
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
