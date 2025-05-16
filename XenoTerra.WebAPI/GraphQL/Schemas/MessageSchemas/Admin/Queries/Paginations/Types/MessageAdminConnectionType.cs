using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations.Types
{
    public class MessageAdminConnectionType : ObjectType<MessageAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
