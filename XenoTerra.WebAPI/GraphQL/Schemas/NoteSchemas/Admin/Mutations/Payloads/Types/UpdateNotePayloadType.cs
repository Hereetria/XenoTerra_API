using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateNotePayloadType : ObjectType<UpdateNotePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateNotePayload> descriptor)
        {
        }
    }
}
