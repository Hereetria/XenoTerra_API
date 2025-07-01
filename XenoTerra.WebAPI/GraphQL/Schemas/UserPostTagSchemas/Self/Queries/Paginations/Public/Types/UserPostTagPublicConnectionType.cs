using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Public.Types
{
    public class UserPostTagPublicConnectionType : ObjectType<UserPostTagPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
