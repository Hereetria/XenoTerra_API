using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types.Self.Own
{
    public class NotificationOwnType : ObjectType<ResultNotificationOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationOwnDto> descriptor)
        {
            descriptor.Name("ResultNotificationOwn");
        }
    }
}
