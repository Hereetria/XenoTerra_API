using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateNoteAdminPayloadType : ObjectType<CreateNoteAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateNoteAdminPayload> descriptor)
        {
        }
    }
}
