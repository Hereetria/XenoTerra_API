using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedNoteType : ObjectType<ResultNoteDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNoteDto> descriptor)
        {
            descriptor.Field(f => f.NoteId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Text)
                .Type<StringType>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
