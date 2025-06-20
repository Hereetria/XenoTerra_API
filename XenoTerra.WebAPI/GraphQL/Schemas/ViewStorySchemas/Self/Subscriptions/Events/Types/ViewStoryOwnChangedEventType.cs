using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStoryOwnChangedEventType : ObjectType<ViewStoryOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryOwnChangedEvent> descriptor)
        {
        }
    }
}
