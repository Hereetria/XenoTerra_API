using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedNotificationType : ObjectType<ResultNotificationDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationDto> descriptor)
        {
            descriptor.Field(f => f.NotificationId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Message)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Image)
                .Type<StringType>();

            descriptor.Field(f => f.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
