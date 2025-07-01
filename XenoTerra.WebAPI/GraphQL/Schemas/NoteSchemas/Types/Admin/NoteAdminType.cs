using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Admin
{
    public class NoteAdminType : ObjectType<ResultNoteAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteAdminDto> descriptor)
        {
            descriptor.Name("ResultNoteAdmin");
        }
    }
}
