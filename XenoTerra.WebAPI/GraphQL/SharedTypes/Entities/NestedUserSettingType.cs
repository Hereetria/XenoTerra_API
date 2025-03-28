using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedUserSettingType : ObjectType<ResultUserSettingDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingDto> descriptor)
        {
            descriptor.Field(f => f.UserSettingId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.IsPrivate)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.ReceiveNotifications)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.ShowActivityStatus)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.LastUpdated)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
