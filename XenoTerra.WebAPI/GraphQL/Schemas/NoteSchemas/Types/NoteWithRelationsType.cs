using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types
{
    public class NoteWithRelationsType : ObjectType<ResultNoteWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultNoteWithRelations");
        }
    }
}
