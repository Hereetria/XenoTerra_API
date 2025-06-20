using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public.Types
{
    public class PostLikePublicConnectionType : ObjectType<PostLikePublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikePublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
