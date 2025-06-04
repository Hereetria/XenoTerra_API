using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations.Types
{
    public class CommentLikeAdminConnectionType : ObjectType<CommentLikeAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
