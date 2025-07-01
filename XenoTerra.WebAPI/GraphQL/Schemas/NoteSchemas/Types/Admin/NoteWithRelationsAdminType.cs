using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Admin
{
    public class NoteWithRelationsAdminType : ObjectType<ResultNoteWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultNoteWithRelationsAdmin");
        }
    }
}
