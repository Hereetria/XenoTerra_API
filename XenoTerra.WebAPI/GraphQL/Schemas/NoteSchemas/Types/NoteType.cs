using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types
{
    public class NoteType : ObjectType<ResultNoteDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteDto> descriptor)
        {
            descriptor.Name("ResultNote");
        }
    }
}
