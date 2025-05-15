using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateNoteInputType : InputObjectType<CreateNoteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateNoteInput> descriptor)
        {
        }
    }
}
