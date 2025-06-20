using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Own.Types
{
    public class MessageOwnConnectionType : ObjectType<MessageOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
