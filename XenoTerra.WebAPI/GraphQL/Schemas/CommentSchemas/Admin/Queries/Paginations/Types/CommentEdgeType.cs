using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations.Types
{
    public class CommentEdgeType : ObjectType<CommentEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentEdge> descriptor)
        {
        }
    }
}
