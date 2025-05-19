using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryAdminChangedEventType : ObjectType<StoryAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryAdminChangedEvent> descriptor)
        {
        }
    }
}