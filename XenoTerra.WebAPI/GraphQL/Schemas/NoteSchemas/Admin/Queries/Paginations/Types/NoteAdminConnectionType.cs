using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations.Types
{
    public class NoteAdminConnectionType : ObjectType<NoteAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
