using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteNoteAdminPayloadType : ObjectType<DeleteNoteAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteNoteAdminPayload> descriptor)
        {
        }
    }
}
