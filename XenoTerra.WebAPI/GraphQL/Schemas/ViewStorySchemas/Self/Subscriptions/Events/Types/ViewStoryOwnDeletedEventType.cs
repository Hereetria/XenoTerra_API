using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events.Types
{
    public class ViewStoryOwnDeletedEventType : ObjectType<ViewStoryOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryOwnDeletedEvent> descriptor)
        {
        }
    }
}
