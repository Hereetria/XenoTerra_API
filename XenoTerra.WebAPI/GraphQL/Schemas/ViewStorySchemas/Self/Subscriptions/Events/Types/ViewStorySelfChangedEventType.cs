using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStorySelfChangedEventType : ObjectType<ViewStorySelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfChangedEvent> descriptor)
        {
        }
    }
}
