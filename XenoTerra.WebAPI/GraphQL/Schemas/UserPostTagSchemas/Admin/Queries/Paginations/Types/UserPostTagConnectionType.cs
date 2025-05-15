using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations.Types
{
    public class UserPostTagConnectionType : ObjectType<UserPostTagConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
