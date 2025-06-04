using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations.Types
{
    public class PostLikeAdminConnectionType : ObjectType<PostLikeAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
