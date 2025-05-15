using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateNotePayloadType : ObjectType<CreateNotePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateNotePayload> descriptor)
        {
        }
    }
}
