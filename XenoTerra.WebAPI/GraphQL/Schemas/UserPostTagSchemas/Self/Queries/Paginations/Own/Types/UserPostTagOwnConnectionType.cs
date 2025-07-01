using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Own.Types
{
    public class UserPostTagOwnConnectionType : ObjectType<UserPostTagOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
