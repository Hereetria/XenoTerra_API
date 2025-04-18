namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Paginations.Types
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
