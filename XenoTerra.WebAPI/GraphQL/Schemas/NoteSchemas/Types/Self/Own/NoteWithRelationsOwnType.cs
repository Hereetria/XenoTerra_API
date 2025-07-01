using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Types.Self.Own
{
    public class NoteWithRelationsOwnType : ObjectType<ResultNoteWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultNoteWithRelationsOwn");
        }
    }
}
