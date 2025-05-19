using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStorySelfDeletedEventType : ObjectType<ViewStorySelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfDeletedEvent> descriptor)
        {
        }
    }
}
