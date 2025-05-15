using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteNotePayloadType : ObjectType<DeleteNotePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteNotePayload> descriptor)
        {
        }
    }
}
