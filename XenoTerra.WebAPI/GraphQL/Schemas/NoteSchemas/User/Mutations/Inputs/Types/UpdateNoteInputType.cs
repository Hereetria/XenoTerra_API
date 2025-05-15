using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs.Types
{
    public class UpdateNoteInputType : InputObjectType<UpdateNoteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateNoteInput> descriptor)
        {
        }
    }
}
