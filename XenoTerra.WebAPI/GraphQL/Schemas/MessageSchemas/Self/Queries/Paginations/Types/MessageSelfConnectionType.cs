using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Types
{
    public class MessageSelfConnectionType : ObjectType<MessageSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
