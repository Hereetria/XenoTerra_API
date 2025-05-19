using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeAdminChangedEventType : ObjectType<LikeAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeAdminChangedEvent> descriptor)
        {
        }
    }
}
