using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations.Types
{
    public class PostAdminConnectionType : ObjectType<PostAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
