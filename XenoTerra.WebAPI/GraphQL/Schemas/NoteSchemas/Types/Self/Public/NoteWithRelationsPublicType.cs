using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Self.Public
{
    public class NoteWithRelationsPublicType : ObjectType<ResultNoteWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultNoteWithRelationsPublic");
        }
    }
}
