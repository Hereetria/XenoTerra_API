using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations.Types
{
    public class PostEdgeType : ObjectType<PostEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<PostEdge> descriptor)
        {
        }
    }
}
