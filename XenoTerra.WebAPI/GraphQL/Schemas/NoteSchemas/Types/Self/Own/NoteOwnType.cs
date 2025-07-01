using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Self.Own
{
    public class NoteOwnType : ObjectType<ResultNoteOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteOwnDto> descriptor)
        {
            descriptor.Name("ResultNoteOwn");
        }
    }
}
