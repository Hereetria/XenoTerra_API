using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations.Types
{
    public class UserPostTagSelfConnectionType : ObjectType<UserPostTagSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
