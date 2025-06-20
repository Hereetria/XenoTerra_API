using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStoryOwnUpdatedEventType : ObjectType<ViewStoryOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryOwnUpdatedEvent> descriptor)
        {
        }
    }
}
