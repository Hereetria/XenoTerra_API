using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types.Self.Own
{
    public class NotificationWithRelationsOwnType : ObjectType<ResultNotificationWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultNotificationWithRelationsOwn");
        }
    }
}
