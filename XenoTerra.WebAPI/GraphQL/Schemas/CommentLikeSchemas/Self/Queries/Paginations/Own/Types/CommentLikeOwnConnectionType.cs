using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Own.Types
{
    public class CommentLikeOwnConnectionType : ObjectType<CommentLikeOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
