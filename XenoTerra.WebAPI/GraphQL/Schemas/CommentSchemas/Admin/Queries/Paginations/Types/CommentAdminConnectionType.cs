using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations.Types
{
    public class CommentAdminConnectionType : ObjectType<CommentAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
