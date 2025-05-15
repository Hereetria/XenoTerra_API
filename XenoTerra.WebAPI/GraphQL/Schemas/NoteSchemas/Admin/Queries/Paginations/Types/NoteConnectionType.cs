using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations.Types
{
    public class NoteConnectionType : ObjectType<NoteConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
