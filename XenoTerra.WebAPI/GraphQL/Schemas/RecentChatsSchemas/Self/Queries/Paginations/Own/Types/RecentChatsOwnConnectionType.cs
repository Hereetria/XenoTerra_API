using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Own.Types
{
    public class RecentChatsOwnConnectionType : ObjectType<RecentChatsOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
