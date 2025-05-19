using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStorySelfUpdatedEventType : ObjectType<ViewStorySelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfUpdatedEvent> descriptor)
        {
        }
    }
}
