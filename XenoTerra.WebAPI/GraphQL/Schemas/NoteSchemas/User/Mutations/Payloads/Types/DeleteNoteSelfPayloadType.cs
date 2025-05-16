using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteNoteSelfPayloadType : ObjectType<DeleteNoteSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteNoteSelfPayload> descriptor)
        {
        }
    }
}
