using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedMessageType : ObjectType<ResultMessageDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMessageDto> descriptor)
        {
            descriptor.Field(f => f.MessageId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Content)
                .Type<StringType>();

            descriptor.Field(f => f.SenderId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.ReceiverId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Header)
                .Type<StringType>();

            descriptor.Field(f => f.SentAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
