using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Types
{
    public class RecentChatsSelfConnectionType : ObjectType<RecentChatsSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
