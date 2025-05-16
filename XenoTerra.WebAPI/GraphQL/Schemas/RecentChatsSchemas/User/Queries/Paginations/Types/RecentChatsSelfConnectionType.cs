using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations.Types
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
