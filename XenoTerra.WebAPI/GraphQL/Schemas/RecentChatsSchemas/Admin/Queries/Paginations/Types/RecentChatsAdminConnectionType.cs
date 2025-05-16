using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations.Types
{
    public class RecentChatsAdminConnectionType : ObjectType<RecentChatsAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
