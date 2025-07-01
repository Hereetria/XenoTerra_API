using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Self.Public
{
    public class NotePublicType : ObjectType<ResultNotePublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotePublicDto> descriptor)
        {
            descriptor.Name("ResultNotePublic");
        }
    }
}
