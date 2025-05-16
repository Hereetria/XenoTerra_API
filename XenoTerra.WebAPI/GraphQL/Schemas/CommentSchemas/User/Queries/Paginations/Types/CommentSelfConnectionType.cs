using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations.Types
{
    public class CommentSelfConnectionType : ObjectType<CommentSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
