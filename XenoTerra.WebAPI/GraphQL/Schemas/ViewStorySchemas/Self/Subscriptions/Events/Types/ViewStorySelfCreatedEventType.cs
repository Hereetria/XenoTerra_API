using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStorySelfCreatedEventType : ObjectType<ViewStorySelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfCreatedEvent> descriptor)
        {
        }
    }
}
