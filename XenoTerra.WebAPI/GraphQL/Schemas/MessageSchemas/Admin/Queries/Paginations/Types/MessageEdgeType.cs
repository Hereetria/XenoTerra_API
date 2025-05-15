using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations.Types
{
    public class MessageEdgeType : ObjectType<MessageEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageEdge> descriptor)
        {
        }
    }
}
