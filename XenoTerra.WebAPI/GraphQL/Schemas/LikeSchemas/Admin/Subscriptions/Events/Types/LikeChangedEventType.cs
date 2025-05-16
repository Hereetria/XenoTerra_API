using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeChangedEventType : ObjectType<LikeChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeChangedAdminEvent> descriptor)
        {
        }
    }
}
