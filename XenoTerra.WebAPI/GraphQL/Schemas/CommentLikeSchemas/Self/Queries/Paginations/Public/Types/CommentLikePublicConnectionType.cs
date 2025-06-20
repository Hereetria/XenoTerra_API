using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public.Types
{
    public class CommentLikePublicConnectionType : ObjectType<CommentLikePublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikePublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
