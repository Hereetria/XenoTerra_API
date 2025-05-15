using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeChangedEventType : ObjectType<LikeChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeChangedEvent> descriptor)
        {
        }
    }
}
