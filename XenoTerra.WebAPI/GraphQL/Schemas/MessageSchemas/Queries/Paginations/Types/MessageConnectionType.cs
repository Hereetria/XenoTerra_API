namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries.Paginations.Types
{
    public class MessageConnectionType : ObjectType<MessageConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
