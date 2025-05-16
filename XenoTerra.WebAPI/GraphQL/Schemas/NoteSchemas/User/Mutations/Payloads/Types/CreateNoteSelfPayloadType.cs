using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateNoteSelfPayloadType : ObjectType<CreateNoteSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateNoteSelfPayload> descriptor)
        {
        }
    }
}
