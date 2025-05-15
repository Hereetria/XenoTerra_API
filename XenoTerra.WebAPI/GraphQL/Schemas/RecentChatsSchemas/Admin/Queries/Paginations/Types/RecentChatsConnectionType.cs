using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations.Types
{
    public class RecentChatsConnectionType : ObjectType<RecentChatsConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
