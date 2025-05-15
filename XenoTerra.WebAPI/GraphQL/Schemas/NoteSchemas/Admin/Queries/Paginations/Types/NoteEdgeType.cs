using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations.Types
{
    public class NoteEdgeType : ObjectType<NoteEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteEdge> descriptor)
        {
        }
    }
}
