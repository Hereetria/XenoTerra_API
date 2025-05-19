using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations.Types
{
    public class UserPublicSelfConnectionType : ObjectType<UserPublicSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPublicSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
