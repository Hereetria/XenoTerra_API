using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Types
{
    public class NotificationWithRelationsType : ObjectType<ResultNotificationWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultNotificationWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultNotificationWithRelations");
        }
    }
}
